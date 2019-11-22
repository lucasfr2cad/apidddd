using System;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class LayoutImplementation : BaseRepository<LayoutEntity>, ILayoutRepository
    {
        public LayoutImplementation(MyContext context) : base(context)
        {
             _dataset = context.Set<LayoutEntity> ();
        }

        public void Insert(LayoutEntity layout)
         {
           try
           {
                _dataset.Add(layout);
                _context.SaveChanges();
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
           
        }

        public  void Update(LayoutEntity layout)
        {
            try
            {
                // pega o objeto e procura no banco - se achar trás o objeto preenchcd_codigoo ou volta nulo
                var result =  _dataset.Find(layout.cd_codigo);
                //se for nulo, para e retorna null
                if(result== null)
                    return;

                layout.ds_nome = result.ds_nome;
                //o contexto pega o result, pega os dados correntes e seta os valores no objeto
                _context.Entry(result).CurrentValues.SetValues(layout);
                //salva no banco
                 _context.SaveChanges();
                //commit ou rollback
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}
