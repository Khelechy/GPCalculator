using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPCalculator.Models
{
    public class Course : IEnumerator
    {
        [Key]
        public string Name { get; set; }
        [MaxLength(2)]
        //[RegularExpression("^[0-9]{1,2}$")]
        public int Unit { get; set; }
        [MaxLength(1)]
        //[RegularExpression("^[a-fA-F]+$", ErrorMessage = "Invalid Grade Entry")]
        public string Grade { get; set; }


        private Course[] courses;
        int position = -1;

        public Course()
        {
            courses = new Course[3]
            {
                new Course(){ Name="Sta 323",Unit= 3, Grade= "A" },
                new Course(){ Name="Mth 323",Unit= 2, Grade= "A" },
                new Course(){ Name="Cos 323",Unit= 3, Grade= "B" },

            };
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public object Current
        {
            get { return courses[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return (position < courses.Length);
        }

        public void Reset()
        {
            position = 0;
        }
    }
}
