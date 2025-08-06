using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace TodoApis.Model
{
    public class TodoList
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Desc { get; set; }

        public List<TodoTask> tasks { get; set; }

    }
}
