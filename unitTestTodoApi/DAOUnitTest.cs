using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApi.Dao;
using TodoApi.Interfaces;
using TodoApi.Model;

namespace unitTestTodoApi
{
    [TestClass]
    public class DAOUnitTest
    {
        private TodoRepository _todosRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _todosRepository = new TodoRepository();
        }

        [TestMethod]
        public void Test_Add()
        {
            _todosRepository.Add(new TodoItem());
            Assert.IsTrue(_todosRepository.Count() == 1);
            Assert.IsTrue(_todosRepository.Get(1) != null);
        }

        [TestMethod]
        public void Test_Add_Check_Id()
        {
            _todosRepository.Add(new TodoItem());
            _todosRepository.Add(new TodoItem());
            Assert.IsTrue(_todosRepository.Get(1) != null);
            Assert.IsTrue(_todosRepository.Get(2) != null);
        }

        [TestMethod]
        public void Test_Add_Check_Id_Continuiter()
        {
            _todosRepository.Add(new TodoItem());
            _todosRepository.Add(new TodoItem());
            _todosRepository.Delete(new TodoItem() {Id = 2});
            _todosRepository.Add(new TodoItem());

            Assert.IsTrue(_todosRepository.Get(1) != null);
            Assert.IsTrue(_todosRepository.Get(2) == null);
            Assert.IsTrue(_todosRepository.Get(3) != null);
        }

        [TestMethod]
        public void Test_Delete()
        {
            var todo = new TodoItem() {Description = "s"};
            TodoItem todo2 = new TodoItem() {Description = "a"};
            _todosRepository.Add(todo);
            _todosRepository.Add(todo2);
            _todosRepository.Delete(todo);
            Assert.IsTrue(_todosRepository.Count() == 1);
        }

        [TestMethod]
        public void Test_Update()
        {
            var todo = new TodoItem() {Description = "Yes a todo item"};
            TodoItem todo2 = new TodoItem() {Description = "Yes a todo item 2"};
            _todosRepository.Add(todo);
            _todosRepository.Add(todo2);
            var newTodo = new TodoItem() {Id = 1,
                
                Description = "updated"};
            _todosRepository.Update(newTodo);

            var todoUpdated = _todosRepository.Get(1);
            Assert.IsTrue(todoUpdated.Description == "updated");
        }
    }
}