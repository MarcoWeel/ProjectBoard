using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ProjectBoard.Model
{
    public class Project
    {
        public Project()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Customer { get; set; }

        [ForeignKey("StepId")] public List<Step> StepList { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedAtDateTime { get; set; }
    }
}
