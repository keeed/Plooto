using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plooto.Core.Exceptions;
using Plooto.Core.Models;
using Plooto.Core.Repositories;
using Plooto.Repositories.EFCore.Translators;

namespace Plooto.Repositories.EFCore
{
    public class InMemoryTodoCommandRepository : ITodoCommandRepository
    {
        public InMemoryTodoCommandRepository(TodoDbContext todoDbContext)
        {
            TodoDbContext = todoDbContext;
        }

        public TodoDbContext TodoDbContext { get; }

        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            var translatedTodo = TodoTranslator.Translate(todo);

            TodoDbContext.Add(translatedTodo);
            await TodoDbContext.SaveChangesAsync();

            return TodoTranslator.Translate(translatedTodo);
        }

        public async Task<Todo> DeleteTodoAsync(Todo todo)
        {
            var foundTodo = await TodoDbContext.Todos.FindAsync(todo.Id);
            if (foundTodo == null)
            {
                throw new TodoNotFoundException(todo.Id.ToString());
            }

            TodoDbContext.Todos.Remove(foundTodo);
            await TodoDbContext.SaveChangesAsync();

            return TodoTranslator.Translate(foundTodo);
        }

        public async Task<Todo> UpdateTodoAsync(Todo todo)
        {
            var translatedTodo = TodoTranslator.Translate(todo);

            try
            {
                var foundTodo = TodoDbContext.Todos.FirstOrDefault(t => t.Id == translatedTodo.Id);

                if (foundTodo == null)
                {
                    throw new TodoNotFoundException(foundTodo.Id.ToString());
                }

                foundTodo.Name = string.IsNullOrEmpty(translatedTodo.Name) ? foundTodo.Name : translatedTodo.Name;
                foundTodo.Completed = translatedTodo.Completed;

                TodoDbContext.Todos.Update(foundTodo);
                await TodoDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(translatedTodo))
                {
                    throw new TodoNotFoundException(translatedTodo.Id.ToString());
                }
                else
                {
                    throw;
                }
            }

            return TodoTranslator.Translate(translatedTodo);
        }

        private bool TodoExists(Repositories.EFCore.Models.Todo todo)
        {
            return TodoDbContext.Todos.Any(t => t.Id == todo.Id);
        }
    }
}