using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext, new()
    {
        public List<TEntity> getAll()
        {
            using(var db =new TContext()){
               return db.Set<TEntity>().ToList();
               
            }
        }

        public void Create(TEntity entity)
        {
            using(var db =new TContext()){
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
             using(var db =new TContext()){

                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
            }
        }

        public TEntity getById(int id)
        {
            using(var db=new TContext()){
              return  db.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity entity)
        {
              using(var db=new TContext()){

                db.Entry(entity).State=EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}