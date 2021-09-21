using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {

        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("123", "aa",  DateTime.Now);

        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Task to be tested right now", "qwerty12345", DateTime.Now);

        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Given_Invalid_Command_Should_Stop_Excecution()
        {   
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Given_Valid_Command_Should_Create_Task()
        {   
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}