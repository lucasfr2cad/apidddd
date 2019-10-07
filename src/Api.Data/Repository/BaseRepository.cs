using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly MyContext _context;

        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                 // pega o objeto e procura no banco - se achar trás o objeto  ou volta nulo
                 var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                //se for nulo, para e retorna false
                if(result== null)
                    return false;
                
                //remove e salva no banco retornando true;
                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
           try
           {
               //veriufica se veio com Id, se não seta com Guid
               if(item.Id == Guid.Empty){
                   item.Id = Guid.NewGuid();
               }
               //cria o creatat com o a data correta do servidor
                item.CreateAt = DateTime.UtcNow;
                //add o item ao banco
                _dataset.Add(item);
                //salva no banco se deu tudo ok
                await _context.SaveChangesAsync();
           }

          
           catch (Exception ex)
           {
               
               throw ex;
           }
           return item;
        }

        public Task<T> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        //recebe uma entidade
        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                // pega o objeto e procura no banco - se achar trás o objeto preenchido ou volta nulo
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                //se for nulo, para e retorna null
                if(result== null)
                    return null;
                
                //atualiza os campos de updateat e createat
                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                //o contexto pega o result, pega os dados correntes e seta os valores no objeto
                _context.Entry(result).CurrentValues.SetValues(item);
                //salva no banco
                await _context.SaveChangesAsync();
                //commit ou rollback
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            //se deu certo retorna o item
            return item;
        }
    }
}
