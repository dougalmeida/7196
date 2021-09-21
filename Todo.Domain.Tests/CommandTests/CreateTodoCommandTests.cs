using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("123", "aa",  DateTime.Now);

        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Task to be tested right now", "qwerty12345", DateTime.Now);


        [TestMethod]
        public void Given_Invalid_Command()
        {            
            _invalidCommand.Validate();

            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Given_Valid_Command()
        {            
            _validCommand.Validate();

            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
