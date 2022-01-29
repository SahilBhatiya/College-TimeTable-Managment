using System.ComponentModel.DataAnnotations;

namespace TimeTable_Creator.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public int BatchId { get; set; }
        
        
        public ICollection<Slot>? slots { get; set; }
    }
}
