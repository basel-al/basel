using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03OOP_Principles
{
    public class Person
    {
        int age;
        decimal salary;
        string address;
    }
    class Student : Person
    {
        public Student()
        {

        }
        List<Course> courses = new List<Course>();
        Dictionary<Course, char> myMap = new Dictionary<Course, char>();
        double GPA(char[] grades)
        {
            int sum = 0;
            foreach(char gr in grades)
            {
                switch(gr)
                {
                    case 'A':
                        sum = sum + 4;
                        break;                      
                    case 'B': 
                        sum = sum + 3;
                        break;
                    case 'C': 
                        sum = sum + 2;
                        break;
                    case 'D':  
                        sum = sum + 1;
                        break;
                    
                }
            }
            return (sum / (grades.Length));
        }

    }
    public class Instructor : Person
    {
        Department dept;
        public Department Dept { get => dept; set => dept = value; }
        bool depthead;
        public bool Depthead { get => depthead; set => depthead = value; }
        DateTime join_Date;
        public DateTime Join_Date { get => join_Date; set => join_Date = value; }
        
        Instructor(Department thedept, bool thedepthead, DateTime theJoin_Date)
        {
            dept = thedept;
            depthead = thedepthead;
            Join_Date = theJoin_Date;
        }
    }
}
