using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plooto.Core.Models;

namespace Plooto.Core
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllTodosAsync();
        Task<Todo> GetTodoAsync(long id);
        Task<Todo> CreateTodoAsync(Todo todo);
        Task<Todo> UpdateTodoAsync(Todo todo);
        Task<Todo> DeleteTodoAsync(Todo todo);
    }
}
