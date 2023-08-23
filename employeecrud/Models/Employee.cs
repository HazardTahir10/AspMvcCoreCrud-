using System.ComponentModel.DataAnnotations;

namespace employeecrud.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        public string Designation { get; set; }
       
        public string Address { get; set; }
        public DateTime? RecordCreatedOn { get; set; } = DateTime.Now; 
    }
}
