using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Entity
{
    public class EntityBase
    {
        public int Id              { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public EntityBase()
        {
            CreateTime = DateTime.Now;
            UpdateTime = CreateTime;
        }
    }
}
