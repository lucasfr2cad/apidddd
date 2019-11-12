using Api.Domain.Entities;

namespace Api.Domain.Dtos
{
    public class UserReportDTO : UserEntity
    {

    public string Nome { get; set; }

    public string Senha { get; set; }
        
    }
}
