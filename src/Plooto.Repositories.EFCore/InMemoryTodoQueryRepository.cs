using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plooto.Core.Exceptions;
using Plooto.Core.Models;
using Plooto.Repositories.EFCore;
using Plooto.Repositories.EFCore.Translators;

namespace Plooto.Core.Repositories
{
    public class InMemoryTodoQueryRepository : ITodoQueryRepository
    {
        public InMemoryTodoQueryRepository(TodoDbContext todoDbContext)
        {
            TodoDbContext = todoDbContext;
        }

        public TodoDbContext TodoDbContext { get; }

        public async Task<List<Todo>> GetAllTodosAsync()
        {
            var result = await TodoDbContext.Todos.ToListAsync();
            return result.ConvertAll(TodoTranslator.Translate);
        }

        public async Task<Todo> GetTodoAsync(long id)
        {
            var todo = await TodoDbContext.Todos.FindAsync(id);

            if (todo == null)
            {
                throw new TodoNotFoundException(id.ToString());
            }

            return TodoTranslator.Translate(todo);
        }
    }
}