using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03OOP_Principles
{
    public class Course
    {
        private int coursenumber;
        private List<object> enrolledStudents;
        public int Coursenumber
        {
            get { return coursenumber; }
            set { coursenumber = value; }
        }
        public List<object> EnrolledStudents
        {
            get { return enrolledStudents; }
            set { enrolledStudents = value; }

        }

    }
}
