using System.ComponentModel.DataAnnotations;

namespace TimeTable_Creator.Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string? studentCount { get; set; }
        public string? Description { get; set; }
        public string? code { get; set; }

        public ICollection<Slot>? slots { get; set; }
    }
}
