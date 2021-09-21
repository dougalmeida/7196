using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Task title qwerty", "qwerty", DateTime.Now);

        [TestMethod]
        public void Given_New_Todo_It_Could_Be_Concluded()
        {            
            Assert.AreEqual(_validTodo.Done, false);
        }
    }

}