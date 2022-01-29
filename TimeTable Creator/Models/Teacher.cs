using System.ComponentModel.DataAnnotations;

namespace TimeTable_Creator.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string ShortForm { get; set; }

        public ICollection<Slot>? slots { get; set; }
    }
}
