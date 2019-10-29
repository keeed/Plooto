using System.ComponentModel.DataAnnotations;

namespace Plooto.Repositories.EFCore.Models
{
    public class Todo 
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}