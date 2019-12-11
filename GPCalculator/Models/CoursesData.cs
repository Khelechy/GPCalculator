using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GPCalculator.Models;

namespace GPCalculator.Models
{
    public class CoursesData :IEnumerator, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<CourseModel> _courses;
        public CoursesData()
        {
            
            _courses = new ObservableCollection<CourseModel>();
            _courses.Add(new CourseModel { name = "Sta 323", unit = 3, grade = "A" });
            _courses.Add(new CourseModel { name = "Mth 323", unit = 2, grade = "A" });
            _courses.Add(new CourseModel { name = "Cos 323", unit = 3, grade = "B" });


        }

        public ObservableCollection<CourseModel> Courses
        {
            get
            {
                return _courses;
            }
            set
            {
                if (_courses != value)
                {
                    _courses = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Courses"));
                }
            }
        }

       

        private void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public object Current
        {
            get { return _courses[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return (position < courses.Count);
        }

        public void Reset()
        {
            position = 0;
        }
    }
}
