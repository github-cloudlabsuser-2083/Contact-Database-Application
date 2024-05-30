using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewWithUserList()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userList = userList;

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userList, result.Model);
        }

        [TestMethod]
        public void Edit_ReturnsNotFoundWhenUserDoesNotExist()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>();
            controller.userList = userList;

            // Act
            var result = controller.Edit(1) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_UpdatesExistingUserAndRedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userList = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" }
            };
            controller.userList = userList;
            var userToUpdate = new User { Id = 1, Name = "Updated John", Email = "updatedjohn@example.com" };

            // Act
            var result = controller.Edit(1, userToUpdate) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            var updatedUser = userList.FirstOrDefault(u => u.Id == 1);
            Assert.IsNotNull(updatedUser);
            Assert.AreEqual("Updated John", updatedUser.Name);
            Assert.AreEqual("updatedjohn@example.com", updatedUser.Email);
        }
    }
}