using System.Collections.Generic;
using System.Threading.Tasks;
using Plooto.Core.Models;

namespace Plooto.Core.Repositories
{
    public interface ITodoQueryRepository
    {
        Task<List<Todo>> GetAllTodosAsync();
        Task<Todo> GetTodoAsync(long id);
    }
}