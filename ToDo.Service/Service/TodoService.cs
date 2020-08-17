using Hangfire;
using Hangfire.Common;
using System;
using System.Collections.Generic;
using ToDo.Data.Interface;
using ToDo.Service.Interface;

namespace ToDo.Service
{
    public class TodoService : ITodoService
    {
      

        private IToDoRepository _todoRepository;
        private ITodoTaskManager _todotaskmanager;

        public TodoService(IToDoRepository TodoRepository, ITodoTaskManager todotaskmanager)
        {
            
            _todoRepository = TodoRepository;
            _todotaskmanager = todotaskmanager;
            _todotaskmanager.SetRepository(_todoRepository);
        }
        public void Delete(Entity.ToDo Entity)
        {
            _todoRepository.Delete(Entity);
            _todotaskmanager.RemoveJob(Entity);
        }

        public Entity.ToDo FindById(int EntityId)
        {
            return _todoRepository.FindById(EntityId);
        }

        public void Insert(Entity.ToDo Entity)
        {
            _todoRepository.Insert(Entity);
            _todotaskmanager.SetJob(Entity);
        }

        public void Update(Entity.ToDo Entity)
        {
            _todoRepository.Update(Entity);
            _todotaskmanager.Update(Entity);
        }




        public IEnumerable<Entity.ToDo> GetAll()
        {
            return _todoRepository.GetAll();
        }
    }
}
