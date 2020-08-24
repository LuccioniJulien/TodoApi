using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Model
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as TodoItem)?.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
