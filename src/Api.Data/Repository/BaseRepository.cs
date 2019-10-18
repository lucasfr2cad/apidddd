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
        public async Task<bool> DeleteAsync(Guid cd_codigo)
        {
            try
            {
                 // pega o objeto e procura no banco - se achar trás o objeto  ou volta nulo
                 var result = await _dataset.SingleOrDefaultAsync(p => p.cd_codigo.Equals(cd_codigo));
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

        public async Task<bool> ExistAsync(Guid cd_codigo)
        {
            return await _dataset.AnyAsync(p => p.cd_codigo.Equals(cd_codigo));
        }

        public async Task<T> InsertAsync(T item)
        {
           try
           {
               //veriufica se veio com cd_codigo, se não seta com Gucd_codigo
            //    if(item.cd_codigo == Guid.Empty){
            //        item.cd_codigo = Guid.NewGuid();
            //    }
               //cria o creatat com o a data correta do servcd_codigoor
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

        public async Task<T> SelectAsync(Guid cd_codigo)
        {
            try
            {
                //pega o objeto e procura no banco - se achar trás o objeto  ou volta nulo
                return await _dataset.SingleOrDefaultAsync(p => p.cd_codigo.Equals(cd_codigo));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //recebe uma entcd_codigoade
        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                // pega o objeto e procura no banco - se achar trás o objeto preenchcd_codigoo ou volta nulo
                var result = await _dataset.SingleOrDefaultAsync(p => p.cd_codigo.Equals(item.cd_codigo));
                //se for nulo, para e retorna null
                if(result== null)
                    return null;

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
