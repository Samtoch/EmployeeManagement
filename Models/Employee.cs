using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        public string Name { get; set; }
        [Required]
        //[RegularExpression("@gmail")]
        [RegularExpression(@"samueltochi1@gmail.com", ErrorMessage = "Email must be samueltochi1@gmail.com")]
        [Display(Name ="Office Mail")]
        public string Email { get; set; }
        [Required]
        public Dept Department { get; set; }
    }
}
