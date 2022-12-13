using Data.Managers;
using Data.Models;
using TurnosBackend.Controllers;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TurnosBackend.Tests.Controller
{
    public class ClientControllerTests
    {
        [Fact]
        public void ClientController_PostClient_ReturnCreated()
        {
            //Arrange
            //var client = A.Fake<Client>();

            var client = new Client
            {
                Id = 0,
                NumDoc = "645423",
                FirstName = "Carlos",
                LastName = "Perez",
                NumPhone = "7655532",
                IdTypeDoc = 1
            };

            var controller = new ClientController();

            //Act
            var result = controller.PostClient(client);

            //Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void ClientController_GetClients_ReturnOK()
        {
            //Arrange
            var controller = new ClientController();

            //Act
            var result = controller.GetClients();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
