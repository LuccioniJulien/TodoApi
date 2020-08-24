﻿using System;
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
        private readonly List<TodoItem> _todoItems;

        public TodoRepository() => _todoItems = new List<TodoItem>();

        public void Add(TodoItem todo) => _todoItems.Add(todo);

        public void Delete(TodoItem todo) => _todoItems.Remove(todo);

        public int Count() => _todoItems.Count();
    }
}