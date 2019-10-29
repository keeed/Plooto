using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plooto.Core.Exceptions;
using Plooto.Core.Models;
using Plooto.Core.Repositories;

namespace Plooto.Core
{
    public class DefaultTodoService : ITodoService
    {
        public DefaultTodoService(
            ITodoCommandRepository todoCommandRepository,
            ITodoQueryRepository todoQueryRepository)
        {
            TodoCommandRepository = todoCommandRepository;
            TodoQueryRepository = todoQueryRepository;
        }

        public ITodoCommandRepository TodoCommandRepository { get; }
        public ITodoQueryRepository TodoQueryRepository { get; }

        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            try
            {
                return await TodoCommandRepository.CreateTodoAsync(todo);
            }
            catch (Exception ex)
            {
                throw new FailedToCreateTodoException(ex.Message);
            }
        }

        public async Task<Todo> DeleteTodoAsync(Todo todo)
        {
            try
            {
                return await TodoCommandRepository.DeleteTodoAsync(todo);
            }
            catch (TodoNotFoundException ex)
            {
                throw new TodoNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new FailedToDeleteTodoException(ex.Message);
            }
        }

        public async Task<List<Todo>> GetAllTodosAsync()
        {
            try
            {
                return await TodoQueryRepository.GetAllTodosAsync();
            }
            catch (Exception ex)
            {
                throw new FailedToGetAllTodosException(ex.Message);
            }
        }

        public async Task<Todo> GetTodoAsync(long id)
        {
            try
            {
                return await TodoQueryRepository.GetTodoAsync(id);
            }
            catch (TodoNotFoundException ex)
            {
                throw new TodoNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new FailedToGetTodoException(ex.Message);
            }
        }

        public async Task<Todo> UpdateTodoAsync(Todo todo)
        {
            try
            {
                return await TodoCommandRepository.UpdateTodoAsync(todo);
            }
            catch (TodoNotFoundException ex)
            {
                throw new TodoNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new FailedToUpdateTodoException(ex.Message);
            }
        }
    }
}