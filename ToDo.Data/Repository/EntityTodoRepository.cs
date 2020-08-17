using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Data.Context;
using ToDo.Data.Interface;

namespace ToDo.Data.Repository
{
    public class EntityTodoRepository : IToDoRepository
    {
        private TodoContext _context;
        public EntityTodoRepository(TodoContext context)
        {
            _context = context;
        }
 
        public void Delete(Entity.ToDo Entity)
        {
            _context.ToDo.Remove(Entity);
            _context.SaveChanges();
        }

        public Entity.ToDo FindById(int EntityId)
        {
            return _context.ToDo.AsNoTracking().FirstOrDefault(x => x.Id == EntityId);
        }

        public IEnumerable<Entity.ToDo> GetAll()
        {
            return _context.ToDo.AsNoTracking().ToList();
        }

        public IEnumerable<Entity.ToDo> GetAllActive()
        {
            return _context.ToDo.AsNoTracking().Where(x => x.ExecuteTime > DateTime.Now).ToList();
        }

        public void Insert(Entity.ToDo Entity)
        {
            _context.ToDo.Add(Entity);
            _context.SaveChanges();
        }

        public void Update(Entity.ToDo Entity)
        {
            _context.ToDo.Update(Entity);
            _context.SaveChanges();
        }
    }
}
