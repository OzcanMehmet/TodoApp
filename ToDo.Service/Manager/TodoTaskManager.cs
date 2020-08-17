using Hangfire;
using Hangfire.Common;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Interface;
using ToDo.Service.Interface;

namespace ToDo.Service
{

    public class TodoTaskManager : ITodoTaskManager
    {
     
        private bool Loaded { get; set; }
        private Dictionary<int, string> jobs { get; set; }

        private IToDoRepository _todoRepository;

        public TodoTaskManager()
        {
            jobs = new Dictionary<int, string>();
            Loaded = false;
        }

        public void SetRepository(IToDoRepository TodoRepository)
        {
            _todoRepository = TodoRepository;
            LoadTodoTask();
        }
        private void LoadTodoTask()
        {
            if (!Loaded)
                foreach (Entity.ToDo todo in _todoRepository.GetAllActive())
                    SetJob(todo);


            Loaded = true;
        }
 
        public void SetJob(Entity.ToDo Entity)
        {
            TimeSpan difftime = Entity.ExecuteTime - DateTime.Now;
            string jobid=null;
            if (difftime > TimeSpan.Zero)
                jobid = BackgroundJob.Schedule<MyHubHelper>(context=>context.SendData(Entity),           
                 difftime); 
           
            jobs.Add(Entity.Id, jobid);
        }
        public void RemoveJob(Entity.ToDo Entity)
        {
            if (jobs.ContainsKey(Entity.Id))
            {
                jobs.TryGetValue(Entity.Id, out string jobid);
                if (jobid != null)
                {
                    BackgroundJob.Delete(jobid);
                }
                jobs.Remove(Entity.Id);
            }


        }
        public void Update(Entity.ToDo Entity)
        {
            RemoveJob(Entity);
            SetJob(Entity);
        }

     
    }
}
