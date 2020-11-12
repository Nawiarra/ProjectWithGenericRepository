using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Interfaces;
using WoodWorkshop.Data.Models;
using System.Data.Entity.Validation;

namespace WoodWorkshop.Data.Repositories
{
    public class WoodWorkshopRepository<TEntity> : IWoodWorkshopRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _ctx;
        private readonly DbSet<TEntity> _dbSet;
        string errorMessage = string.Empty;

        public WoodWorkshopRepository(DbContext context)
        {
            _ctx = context;
            _dbSet = _ctx.Set<TEntity>();
        }

        public TEntity Create(TEntity model)
        {
            var entity = _dbSet.Add(model);
            _ctx.SaveChanges();
            return entity;
        }

        public List<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public List<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public bool Remove(TEntity model)
        {
            try
            {
                _dbSet.Remove(model);
                _ctx.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void Update(TEntity model)
        {
            try
            {
                if (_dbSet == null)
                {
                    throw new ArgumentNullException("entity");
                }

                _ctx.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(errorMessage, dbEx);
            }
        }

        public TEntity GetById(object id)
        {
            TEntity result = _dbSet.Find(id);
            return result;

        }
    }
}
