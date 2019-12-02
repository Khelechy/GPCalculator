using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPCalculator.Models
{
    public class Course
    {
        [Key]
        public int Sn { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        [MaxLength]
        public string Grade { get; set; }
    }
}
