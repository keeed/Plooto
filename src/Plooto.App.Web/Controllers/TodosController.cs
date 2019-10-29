using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plooto.App.Web.Models;
using Plooto.App.Web.Translators;
using Plooto.Core;
using Plooto.Core.Exceptions;

namespace Plooto.App.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        public TodosController(ITodoService todoService)
        {
            TodoService = todoService;
        }

        public ITodoService TodoService { get; }

        [HttpGet]
        public async Task<ActionResult<List<TodoDTO>>> GetAllTodos()
        {
            var results = await TodoService.GetAllTodosAsync();

            return results.ConvertAll(TodoTranslator.Translate);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDTO>> GetTodo(long id)
        {
            try
            {
                var result = await TodoService.GetTodoAsync(id);
                return TodoTranslator.Translate(result);
            }
            catch (TodoNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TodoDTO>> PostTodo(CreateTodoRequest request)
        {
            var result =
                await TodoService.CreateTodoAsync(
                    new Core.Models.Todo()
                    {
                        Name = request.Name,
                        Completed = false
                    });

            var translatedResult = TodoTranslator.Translate(result);

            return CreatedAtAction(nameof(GetTodo), new { translatedResult.Id }, translatedResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(long id, UpdateTodoRequest request)
        {
            var todo =
                new Core.Models.Todo()
                {
                    Id = id,
                    Name = request.Name,
                    Completed = request.Completed
                };

            try
            {
                await TodoService.UpdateTodoAsync(todo);
            }
            catch (TodoNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoDTO>> DeleteTodo(long id)
        {
            try
            {
                var deletedTodo =
                    await TodoService.DeleteTodoAsync(
                        new Core.Models.Todo()
                        {
                            Id = id
                        });

                return TodoTranslator.Translate(deletedTodo);
            }
            catch (TodoNotFoundException)
            {
                return NotFound();
            }
        }
    }
}