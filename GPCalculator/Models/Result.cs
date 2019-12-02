using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPCalculator.Models
{
    public class Result
    {
        [Required] 
        public string Lastname { get; set; }
        public int Id { get; set; }
        [Required]
        public string Firstname{ get; set; }
        [Required]
        [MaxLength(11)]
        [RegularExpression(@"^[/0-9]+[\s]*$", ErrorMessage = "Invalid Registration Number format")]
        public string Regno { get; set; }
        [Required]
        public string Department { get; set; }
        public string Level { get; set; }
        [Required]
        [RegularExpression(@"^[/0-9]+[\s]*$", ErrorMessage = "Invalid Session format")]
        public string Session { get; set; }
        public string Semester { get; set; }
        public List<Course> Courses { get; set; }

    }
    
}
