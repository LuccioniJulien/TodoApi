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
            var todo = new TodoItem() { Id = 0, Description = "" };
            _todosRepository.Setup(x => x.Add(null));

            var result = _todoController.Post(todo);

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        [TestMethod]
        public void Test_Add_Fail()
        {
            var todo = new TodoItem() { Id = 0 };
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
            int id = 1;
            var todo = new TodoItem() { Id = id };
            _todosRepository.Setup(x => x.Get(id)).Returns(todo);

            var result = _todoController.Get(id);
            var todoFromGet = (result.Result as OkObjectResult)?.Value as TodoItem;

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsTrue(todo.Equals(todoFromGet));
        }

        [TestMethod]
        public void Test_Get_Not_Found()
        {
            int id = 1;
            _todosRepository.Setup(x => x.Get(id))
                            .Returns<TodoItem>(null);

            var result = _todoController.Get(id);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }
        #endregion
    }
}
