using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Model;

namespace TodoApi.Interfaces
{
    interface ITodoRepository
    {
        void Add(TodoItem todo);

        void Delete(TodoItem todo);

        int Count();
    }
}
