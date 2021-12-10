using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03OOP_Principles
{
    public class Department
    {
        private Instructor head;
        public Instructor Head { get => head; set => head = value; }

        private int departmentNumber;
        public int DepartmentNumber{ get => departmentNumber; set => departmentNumber = value; }
        private Department dept;
        public Department Dept { get => dept; set => dept = value; }
        private int[] coursenumber;
         public int[] Coursenumber{ get => Coursenumber; set => Coursenumber = value; }
        private decimal budget;
        public decimal Budget { get => budget; set => budget = value; }




}
}
