using BlazorApp.Server;
using BlazorApp.Server.Controllers;
using BlazorApp.Server.Hubs;
using BlazorApp.Server.Services.Interfaces;
using BlazorApp.Server.Services.Repositories;
using BlazorApp.Shared.Models;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BlazorAppTests
{
    public class TodoControllerTest
    {
        [Fact]
        public async void GetAll_IfAnyExist_ReturnObject()
        {
            var context = new Mock<DataContext>();
            context.Setup(x => x.Todos).ReturnsDbSet(GetTodos());

            var logger = Mock.Of<ILogger<TodoRepository>>();
            var repo = new TodoRepository(context.Object, logger);
            var hub = new Mock<IHubContext<MainHub>>();
            
            var controller = new TodoController(hub.Object, repo);
            var result = await controller.GetAll();


            var content = result as OkObjectResult;
            Todo [] data = (Todo[])content.Value;

            Assert.True(data.Length > 0);
            
        }

        public List<Todo>GetTodos()
        {
            return new List<Todo>
            {
                new Todo
                {
                    TodoID=1,
                    Title="title 1",
                    Date= DateTime.Now,
                    Description="my first description",
                },
                 new Todo
                {
                    TodoID=2,
                    Title="title 2",
                    Date= DateTime.Now,
                    Description="my second description",
                }
            };
        }
    }
}
