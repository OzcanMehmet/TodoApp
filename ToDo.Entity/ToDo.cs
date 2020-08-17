using System;

namespace ToDo.Entity
{
    public class ToDo : EntityBase
    {
        public string   Name        { get; set; }  
        public string   Description { get; set; }
        public DateTime ExecuteTime { get; set; }

    }
}
