using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Interfaces
{
    public interface IWoodWorkshopRepository<TEntity> where TEntity : class
    {
            TEntity Create(TEntity model);
            TEntity GetById(object id);
            List<TEntity> Get();
            List<TEntity> Get(Func<TEntity, bool> predicate);
            bool Remove(TEntity model);
            void Update(TEntity model);
    }
}
