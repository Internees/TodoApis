using System.ComponentModel.DataAnnotations;
namespace TodoApis.Model
{
    public class TodoTask
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } 
    }
}
