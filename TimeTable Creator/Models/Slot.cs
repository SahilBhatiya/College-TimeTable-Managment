using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTable_Creator.Models
{
    public class Slot
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string? Link { get; set; }
        public string? Class { get; set; }
        public DateTime StartTime { get; set; }
        public int TimeLength { get; set; }
        public int Day { get; set; }



        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        [ForeignKey("Batch")]
        public int BatchId { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public Teacher? Teacher { get; set; }
        public Batch? Batch { get; set; }
        public Subject? Subject { get; set; }
    }
}
