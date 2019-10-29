using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Plooto.App.Web.Models;
using Xunit;

namespace Plooto.App.Web.Tests
{
    public class TodosControllerIntTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        public TodosControllerIntTests(WebApplicationFactory<Startup> factory)
        {
            Factory = factory;
        }

        public WebApplicationFactory<Startup> Factory { get; }

        [Fact]
        public async Task Execute_Int_Test_For_Todos()
        {
            // Test 1 - Get all Todos
            await GetAll();
            // Test 2 - Create a new Todo
            await CreateTodo();
            // Test 3 - Get new Todo
            await GetTodo();
            // Test 4 - Update Todo
            await UpdateTodo();
            // Test 5 - Get Update Todo
            await GetUpdatedTodo();
            // Test 6 - Delete Todo
            await DeleteTodo();
            // Test 7 - Deleted todo should not be found.
            await GetDeletedTodo();
        }

        private async Task GetDeletedTodo()
        {
             // Given:
            var client = Factory.CreateClient();

            // When:
            var response = await client.GetAsync("/api/Todos/1");

            // Then:
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        private async Task DeleteTodo()
        {
            // Given:
            var client = Factory.CreateClient();

            // When:
            var response = await client.DeleteAsync("/api/Todos/1");
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseDTO = JsonConvert.DeserializeObject<TodoDTO>(responseBody);

            // Then:
            Assert.Equal(1, responseDTO.Id);
            Assert.Equal("Water Plants", responseDTO.Name);
            Assert.Equal(true, responseDTO.Completed);
        }

        private async Task GetUpdatedTodo()
        {
            // Given:
            var client = Factory.CreateClient();

            // When:
            var response = await client.GetAsync("/api/Todos/1");
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseDTO = JsonConvert.DeserializeObject<TodoDTO>(responseBody);

            // Then:
            Assert.Equal(1, responseDTO.Id);
            Assert.Equal("Water Plants", responseDTO.Name);
            Assert.Equal(true, responseDTO.Completed);
        }

        private async Task UpdateTodo()
        {
            // Given:
            var client = Factory.CreateClient();

            // And:
            var updateTodoRequest = new UpdateTodoRequest()
            {
                Name = "Water Plants",
                Completed = true
            };

            // And:
            HttpContent httpContent = new StringContent(
                JsonConvert.SerializeObject(updateTodoRequest),
                Encoding.UTF8,
                "application/json"
            );

            // When:
            var response = await client.PutAsync("/api/Todos/1", httpContent);

            // Then:
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        private async Task GetTodo()
        {
            // Given:
            var client = Factory.CreateClient();

            // When:
            var response = await client.GetAsync("/api/Todos/1");
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseDTO = JsonConvert.DeserializeObject<TodoDTO>(responseBody);

            // Then:
            Assert.Equal(1, responseDTO.Id);
            Assert.Equal("Water Plants", responseDTO.Name);
            Assert.Equal(false, responseDTO.Completed);
        }

        private async Task CreateTodo()
        {
            // Given:
            var client = Factory.CreateClient();

            // And:
            var createTodoRequest = new CreateTodoRequest()
            {
                Name = "Water Plants"
            };

            // And:
            HttpContent httpContent = new StringContent(
                JsonConvert.SerializeObject(createTodoRequest),
                Encoding.UTF8,
                "application/json"
            );

            // When:
            var response = await client.PostAsync("/api/Todos", httpContent);
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseDTO = JsonConvert.DeserializeObject<TodoDTO>(responseBody);

            // Then:
            Assert.Equal(1, responseDTO.Id);
            Assert.Equal("Water Plants", responseDTO.Name);
            Assert.Equal(false, responseDTO.Completed);
        }

        private async Task GetAll()
        {
            var client = Factory.CreateClient();

            // When:
            var response = await client.GetAsync("/api/Todos");
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseDTO = JsonConvert.DeserializeObject<List<TodoDTO>>(responseBody);

            // Then:
            Assert.Equal(0, responseDTO.Count);
        }
    }
}
