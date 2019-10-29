using System.ComponentModel.DataAnnotations;

namespace Plooto.App.Web.Models
{
    public class UpdateTodoRequest 
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}