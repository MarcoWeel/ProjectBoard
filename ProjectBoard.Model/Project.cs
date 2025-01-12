using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ProjectBoard.Model
{
    public class Project
    {
        public Project() { }

        public Project(string name, string description, string customer, DateTime? dueDate, Priority priority)
        {
            Name = name;
            Description = description;
            Customer = customer;
            StepList = new List<Step>();
            IsCompleted = false;
            IsActive = false;
            DueDate = dueDate;
            CreationDate = DateTime.Now;
            Priority = priority;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Customer { get; set; }

        [ForeignKey("StepId")] public List<Step> StepList { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public Priority Priority { get; set; }
    }

    public enum Priority { Low = 0, Medium = 1, High = 2 }
}
