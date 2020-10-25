using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Model;

namespace TodoApi.Interfaces
{
    public interface ITodoRepository
    {
        void Add(TodoItem todo);
        void Delete(TodoItem todo);
        TodoItem Get(int id);
        List<TodoItem> GetAll();
        int Count();
    }
}
