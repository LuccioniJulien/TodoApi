using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.Model;

namespace TodoApi.Dao
{
    public class TodoRepository : ITodoRepository
    {
        private static int _nbTodo = 1;
        private readonly List<TodoItem> _todoItems;

        public TodoRepository() => _todoItems = new List<TodoItem>();

        public void Add(TodoItem todo)
        {
            todo.Id = TodoRepository._nbTodo++;
            _todoItems.Add(todo);
        }

        public void Delete(TodoItem todo) => _todoItems.Remove(todo);

        public int Count() => _todoItems.Count();

        public TodoItem Get(int id) => _todoItems.FirstOrDefault(t => t.Id == id);

        public List<TodoItem> GetAll() => _todoItems;
    }
}