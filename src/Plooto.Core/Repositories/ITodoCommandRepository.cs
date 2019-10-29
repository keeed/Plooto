using System.Collections.Generic;
using System.Threading.Tasks;
using Plooto.Core.Models;

namespace Plooto.Core.Repositories
{
    public interface ITodoCommandRepository
    {
        Task<Todo> CreateTodoAsync(Todo todo);
        Task<Todo> UpdateTodoAsync(Todo todo);
        Task<Todo> DeleteTodoAsync(Todo todo);
    }
}