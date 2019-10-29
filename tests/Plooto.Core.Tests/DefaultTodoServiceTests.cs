using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Plooto.Core.Exceptions;
using Plooto.Core.Models;
using Plooto.Core.Repositories;
using Xunit;

namespace Plooto.Core.Tests
{
    public class DefaultTodoServiceTests
    {
        [Fact]
        public async Task On_Create_Should_Return_Todo_When_Successful()
        {
            // Given:
            var todoItem = new Todo()
            {
                Id = 0,
                Name = "Water plants",
                Completed = false
            };

            // And:
            var commandRepository = new Mock<ITodoCommandRepository>();
            commandRepository
                .Setup(r => r.CreateTodoAsync(It.IsAny<Todo>()))
                .ReturnsAsync(todoItem);

            // And:
            var sut = new DefaultTodoService(commandRepository.Object, null);

            // When:
            var result = await sut.CreateTodoAsync(todoItem);

            // Then:
            Assert.Equal("Water plants", result.Name);
            Assert.Equal(false, result.Completed);
        }

        [Fact]
        public async Task On_Create_Should_Throw_FailedToCreateException_When_Exception_Received()
        {
            // Given:
            var todoItem = new Todo()
            {
                Id = 0,
                Name = "Water plants",
                Completed = false
            };

            // And:
            var commandRepository = new Mock<ITodoCommandRepository>();
            commandRepository
                .Setup(r => r.CreateTodoAsync(It.IsAny<Todo>()))
                .ThrowsAsync(new NullReferenceException("Problem with database!"));

            // And:
            var sut = new DefaultTodoService(commandRepository.Object, null);

            // When:
            var func = new Func<Task>(async () => { await sut.CreateTodoAsync(todoItem); });

            // Then:
            var exception = await Assert.ThrowsAsync<FailedToCreateTodoException>(func);
            Assert.Equal("Problem with database!", exception.Message);
        }

        [Fact]
        public async Task On_Update_Should_Proceed_When_No_Exception()
        {
            // Given:
            var todoItem = new Todo()
            {
                Id = 0,
                Name = "Water plants",
                Completed = false
            };

            // And:
            var commandRepository = new Mock<ITodoCommandRepository>();
            commandRepository
                .Setup(r => r.UpdateTodoAsync(It.IsAny<Todo>()))
                .ReturnsAsync(todoItem);

            // And:
            var sut = new DefaultTodoService(commandRepository.Object, null);

            // When:
            var result = await sut.UpdateTodoAsync(todoItem);

            // Then:
            Assert.NotNull(result);
        }

        [Fact]
        public async Task On_Update_Should_Throw_TodoNotFoundException_When_TodoNotFoundException_Received()
        {
            // Given:
            var todoItem = new Todo()
            {
                Id = 0,
                Name = "Water plants",
                Completed = false
            };

            // And:
            var commandRepository = new Mock<ITodoCommandRepository>();
            commandRepository
                .Setup(r => r.UpdateTodoAsync(It.IsAny<Todo>()))
                .ThrowsAsync(new TodoNotFoundException(todoItem.Id.ToString()));

            // And:
            var sut = new DefaultTodoService(commandRepository.Object, null);

            // When:
            var func = new Func<Task>(async () => { await sut.UpdateTodoAsync(todoItem); });

            // Then:
            var exception = await Assert.ThrowsAsync<TodoNotFoundException>(func);
            Assert.Equal("0", exception.Message);
        }

        [Fact]
        public async Task On_Update_Should_Throw_FailedToUpdateTodoException_When_Exception_Received()
        {
            // Given:
            var todoItem = new Todo()
            {
                Id = 0,
                Name = "Water plants",
                Completed = false
            };

            // And:
            var commandRepository = new Mock<ITodoCommandRepository>();
            commandRepository
                .Setup(r => r.UpdateTodoAsync(It.IsAny<Todo>()))
                .ThrowsAsync(new NullReferenceException("Problem with database!"));

            // And:
            var sut = new DefaultTodoService(commandRepository.Object, null);

            // When:
            var func = new Func<Task>(async () => { await sut.UpdateTodoAsync(todoItem); });

            // Then:
            var exception = await Assert.ThrowsAsync<FailedToUpdateTodoException>(func);
            Assert.Equal("Problem with database!", exception.Message);
        }

        [Fact]
        public async Task On_Delete_Should_Return_Deleted_Todo()
        {
            // Given:
            var todoItem = new Todo()
            {
                Id = 0,
                Name = "Water plants",
                Completed = false
            };

            // And:
            var commandRepository = new Mock<ITodoCommandRepository>();
            commandRepository
                .Setup(r => r.DeleteTodoAsync(It.IsAny<Todo>()))
                .ReturnsAsync(todoItem);

            // And:
            var sut = new DefaultTodoService(commandRepository.Object, null);

            // When:
            var result = await sut.DeleteTodoAsync(todoItem);

            // Then:
            Assert.Equal(0, result.Id);
            Assert.Equal("Water plants", result.Name);
            Assert.Equal(false, result.Completed);
        }

        [Fact]
        public async Task On_Delete_Should_Throw_TodoNotFoundException_When_TodoNotFoundException_Received()
        {
            // Given:
            var todoItem = new Todo()
            {
                Id = 0,
                Name = "Water plants",
                Completed = false
            };

            // And:
            var commandRepository = new Mock<ITodoCommandRepository>();
            commandRepository
                .Setup(r => r.DeleteTodoAsync(It.IsAny<Todo>()))
                .ThrowsAsync(new TodoNotFoundException(todoItem.Id.ToString()));

            // And:
            var sut = new DefaultTodoService(commandRepository.Object, null);

            // When:
            var func = new Func<Task>(async () => { await sut.DeleteTodoAsync(todoItem); });

            // Then:
            var exception = await Assert.ThrowsAsync<TodoNotFoundException>(func);
            Assert.Equal("0", exception.Message);
        }

        [Fact]
        public async Task On_Delete_Should_Throw_FailedToUpdateTodoException_When_Exception_Received()
        {
            // Given:
            var todoItem = new Todo()
            {
                Id = 0,
                Name = "Water plants",
                Completed = false
            };

            // And:
            var commandRepository = new Mock<ITodoCommandRepository>();
            commandRepository
                .Setup(r => r.DeleteTodoAsync(It.IsAny<Todo>()))
                .ThrowsAsync(new NullReferenceException("Problem with database!"));

            // And:
            var sut = new DefaultTodoService(commandRepository.Object, null);

            // When:
            var func = new Func<Task>(async () => { await sut.DeleteTodoAsync(todoItem); });

            // Then:
            var exception = await Assert.ThrowsAsync<FailedToDeleteTodoException>(func);
            Assert.Equal("Problem with database!", exception.Message);
        }

        [Fact]
        public async Task On_Get_Should_Return_Todo()
        {
            // Given:
            long id = 0;

            // And:
            var queryRepository = new Mock<ITodoQueryRepository>();
            queryRepository
                .Setup(r => r.GetTodoAsync(It.IsAny<long>()))
                .ReturnsAsync(new Todo()
                {
                    Id = 0,
                    Name = "Water plants",
                    Completed = false
                });

            // And:
            var sut = new DefaultTodoService(null, queryRepository.Object);

            // When:
            var result = await sut.GetTodoAsync(id);

            // Then:
            Assert.Equal(0, result.Id);
            Assert.Equal("Water plants", result.Name);
            Assert.Equal(false, result.Completed);
        }

        [Fact]
        public async Task On_Get_Should_Throw_TodoNotFoundException_When_TodoNotFoundException_Received()
        {
            // Given:
            long id = 0;

            // And:
            var queryRepository = new Mock<ITodoQueryRepository>();
            queryRepository
                .Setup(r => r.GetTodoAsync(It.IsAny<long>()))
                .ThrowsAsync(new TodoNotFoundException("0"));

            // And:
            var sut = new DefaultTodoService(null, queryRepository.Object);

            // When:
            var func = new Func<Task>(async () => { await sut.GetTodoAsync(id); });

            // Then:
            var result = await Assert.ThrowsAsync<TodoNotFoundException>(func);
            Assert.Equal("0", result.Message);
        }

        [Fact]
        public async Task On_Get_Should_Throw_FailedToGetTodoException_When_Exception_Received()
        {
            // Given:
            long id = 0;

            // And:
            var queryRepository = new Mock<ITodoQueryRepository>();
            queryRepository
                .Setup(r => r.GetTodoAsync(It.IsAny<long>()))
                .ThrowsAsync(new NullReferenceException("Problems with database!"));

            // And:
            var sut = new DefaultTodoService(null, queryRepository.Object);

            // When:
            var func = new Func<Task>(async () => { await sut.GetTodoAsync(id); });

            // Then:
            var result = await Assert.ThrowsAsync<FailedToGetTodoException>(func);
            Assert.Equal("Problems with database!", result.Message);
        }

        [Fact]
        public async Task On_GetAllTodos_Should_Return_All_Todos()
        {
            // Given:
            var todos = new List<Todo>()
            {
                new Todo()
                {
                    Id = 0,
                    Name = "Water plants",
                    Completed = false
                },
                new Todo()
                {
                    Id = 1,
                    Name = "Wash dishes",
                    Completed = true
                }
            };

            // And:
            var queryRepository = new Mock<ITodoQueryRepository>();
            queryRepository
                .Setup(r => r.GetAllTodosAsync())
                .ReturnsAsync(todos);

            // And:
            var sut = new DefaultTodoService(null, queryRepository.Object);

            // When:
            var result = await sut.GetAllTodosAsync();

            // Then:
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task On_GetAllTodos_Should_Throw_FailedToGetAllTodosException_When_Exception_Received()
        {
            // Given:
            var queryRepository = new Mock<ITodoQueryRepository>();
            queryRepository
                .Setup(r => r.GetAllTodosAsync())
                .ThrowsAsync(new NullReferenceException("Problems with database!"));

            // And:
            var sut = new DefaultTodoService(null, queryRepository.Object);

            // When:
            var func = new Func<Task>(async () => { await sut.GetAllTodosAsync(); });

            // Then:
            var result = await Assert.ThrowsAsync<FailedToGetAllTodosException>(func);
            Assert.Equal("Problems with database!", result.Message);
        }
    }
}
