# API em .Net Core baseada em DDD + SwaggerUI + JWT


O DDD (Domain Driven Design) é uma modelagem de software cujo objetivo é facilitar a implementação de regras e processos complexos, onde visa a divisão de responsabilidades por camadas e é independente da tecnologia utilizada.

![](https://miro.medium.com/max/641/1*qpHCIA7RDfW89KtSUXGJog.png)


1. Camada de aplicação: responsável pelo projeto principal, pois é onde será desenvolvido os controladores e serviços da API. Tem a função de receber todas as requisições e direcioná-las a algum serviço para executar uma determinada ação.
Possui referências das camadas Service e Domain.
2. Camada de domínio: responsável pela implementação de classes/modelos, as quais serão mapeadas para o banco de dados, além de obter as declarações de interfaces, constantes, DTOs (Data Transfer Object) e enums.
3. Camada de serviço: seria o “coração” do projeto, pois é nela que é feita todas as regras de negócio e todas as validações, antes de persistir os dados no banco de dados.
Possui referências das camadas Domain, Data e CrossCutting.
4. Camada de infraestrutura: é dividida em duas.
 Data: realiza a persistência com o banco de dados, utilizando EFCore.
 Cross-Cutting: uma camada a parte que não obedece a hierarquia de camada. Como o próprio nome diz, essa camada cruza toda a hierarquia. Contém as funcionalidades que pode ser utilizada em qualquer parte do código, como, por exemplo, validação de CPF/CNPJ, consumo de API externa e utilização de alguma segurança.
Possui referências da camada Domain.

### Camadas

### Camada Dominio
* Contém duas pastas, uma para declarar as entidades e outra para declarar as interfaces que serão utilizadas
* Dentro da pasta de entidades desenvolve-se uma classe chamada BaseEntity, a qual terá a propriedade Id, UpdateAT e CreateAT. Esta classe será herdada por todas as outras entidades criadas, obrigando todos os modelos a possuírem um Id. E gera-se outra classe chamada User.
* Na pasta destinada as interfaces, desenvolve-se as mesmas referentes a implementação de repositórios e serviços.
* Obs’.: Ambas as interfaces são genéricas, onde recebem um modelo (T) como parâmetro, identificando sobre qual entidade àquela interface irá atuar.


### Data

Essa camada será responsável por conectar ao banco de dados e realizar as persistências.

* Cria-se três pastas chamadas Context, Mapping e Repository.

* Context: ficará a classe de contexto, responsável por conectar no banco de dados e, também, por fazer o mapeamento das tabelas do banco de dados nas entidades.
* Mapping: ficará as classes referente ao mapeamento de cada entidade. Nela realiza-se algumas configurações referente a própria entidade, como, por exemplo, o nome da tabela que vai para o banco de dados, o nome das colunas e qual será a chave primária.
* Repository: ficará as classes responsáveis por realizar o CRUD no banco de dados.

* A intenção é de ter uma única classe, genérica, para realizar o CRUD, onde pode-se passar uma entidade T para ela, e essa classe irá trabalhar em cima dessa entidade. Herda-se a interface IRepository, onde obriga-se a classe a implementar os métodos que definiu-se anteriormente na camada de domínio.


## CrossCutting
* Classes responsavéis por manter a injeção de depêndica nos serviços do startup

## Service

* É uma classe genérica utilizada para centralizar o CRUD, onde passa-se uma entidade como parâmetro, a qual irá trabalhar os serviços em cima da mesma, igualmente feito com o repositório.


## Aplication
* Esta camada é a “porta de entrada” do sistema, pois é nela que conterá os controladores e serviços para efetuar as chamadas na API.
* Dentro da pasta Controllers, cria-se uma classe chamada UserController

![](https://i.imgur.com/odY6lJu.png)
