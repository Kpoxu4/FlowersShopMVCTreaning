using FlowersShopMVCTraining.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public abstract class BaseRepository<DbModel>
         where DbModel : BaseModel
    {
        protected DbContext _dbContext;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<DbModel>();
        }

        public virtual bool Any()
            => _dbSet.Any();

        public virtual List<DbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual DbModel? Get(int id)
        {
            return _dbSet.FirstOrDefault(dbModel => dbModel.Id == id);
        }

        public virtual DbModel Create(DbModel model)
        {
            _dbSet.Add(model);

            _dbContext.SaveChanges();

            return model;
        }

        public virtual void Delete(int id)
        {
            var model = Get(id);

            if (model is null)
            {
                throw new KeyNotFoundException();
            }

            Delete(model);
        }

        public virtual void Delete(DbModel model)
        {
            _dbSet.Remove(model);
            _dbContext.SaveChanges();
        }
    }
}
