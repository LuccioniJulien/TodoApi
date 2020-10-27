using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoApi.Controllers;
using TodoApi.Interfaces;
using TodoApi.Model;

namespace unitTestTodoApi
{
    [TestClass]
    public class ControllerUnitTest
    {
        private Mock<ITodoRepository> _todosRepository;
        private TodoController _todoController;

        [TestInitialize]
        public void TestInitialize()
        {
            _todosRepository = new Mock<ITodoRepository>();
            _todoController = new TodoController(_todosRepository.Object);
        }

        #region POST

        [TestMethod]
        public void Test_Add_Success()
        {
            var todo = new TodoItem() {Id = 0, Description = ""};
            _todosRepository.Setup(x => x.Add(null));

            var result = _todoController.Post(todo);

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        [TestMethod]
        public void Test_Add_Fail()
        {
            var todo = new TodoItem() {Id = 0};
            _todosRepository.Setup(x => x.Add(null));

            _todoController.ModelState.AddModelError("key", "value");
            var result = _todoController.Post(todo);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        #endregion

        #region GET

        [TestMethod]
        public void Test_Get_Success()
        {
            const int id = 1;
            var todo = new TodoItem() {Id = id};
            _todosRepository.Setup(x => x.Get(id))
                .Returns(todo);

            var result = _todoController.Get(id);
            var todoFromGet = (result.Result as OkObjectResult)?.Value as TodoItem;

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsTrue(todo.Equals(todoFromGet));
        }

        [TestMethod]
        public void Test_GetAll_Success()
        {
            var todo = new TodoItem();
            var todo2 = new TodoItem();
            var todos = new List<TodoItem> {todo, todo2};
            _todosRepository.Setup(x => x.GetAll())
                .Returns(todos);

            var resultController = _todoController.Get();
            var todoFromGet = (resultController.Result as OkObjectResult)?.Value as List<TodoItem>;

            Assert.IsInstanceOfType(resultController.Result, typeof(OkObjectResult));
            Assert.IsTrue(todoFromGet?.Count == todos.Count);
        }

        [TestMethod]
        public void Test_Get_Not_Found()
        {
            var id = 1;
            _todosRepository.Setup(x => x.Get(id))
                .Returns<TodoItem>(null);

            var result = _todoController.Get(id);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        #endregion

        #region Delete

        [TestMethod]
        public void Test_Delete_Success()
        {
            const int id = 1;
            var todo = new TodoItem {Id = id};
            _todosRepository.Setup(x => x.Get(1))
                .Returns(todo);
            _todosRepository.Setup(x => x.Delete(todo));

            var result = _todoController.Delete(id);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void Test_Delete_Fail()
        {
            const int id = 1;
            TodoItem todo = null;
            _todosRepository.Setup(x => x.Get(1))
                .Returns(todo);

            var result = _todoController.Delete(id);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        #endregion

        #region PUT

        #endregion
    }
}