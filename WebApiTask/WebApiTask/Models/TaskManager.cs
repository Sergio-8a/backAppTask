using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace WebApiTask.Models
{
    public class TaskManager
    {
        [Key]
        public int Id { get; set; }
        public required string nameTask { get; set; }
        public required string descriptionTask { get; set; }
        public required string statusTask { get; set; }
    }
}
