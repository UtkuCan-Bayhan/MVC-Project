using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopapp.data.Abstract
{
    public interface IRepository<Entity>
    {
           Entity getById(int id);

         List<Entity> getAll();

         void Create(Entity entity);

         void Update(Entity entity);

         void Delete (Entity entity);
    }
}