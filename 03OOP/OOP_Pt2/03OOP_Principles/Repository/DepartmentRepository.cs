using ConsoleApp3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03OOP_Principles.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        List<Department> lstDepartments = new List<Department>();
        public int Delete(int id)
        {
            Department c = GetById(id);
            if (c != null)
            {
                lstDepartments.Remove(c);
                return 1;
            }
            return 0;
        }
        public List<Department> GetAll()
        {
            return lstDepartments;
        }
        public Department GetById(int id)
        {
            for (int i = 0; i < lstDepartments.Count; i++)
            {
                if (lstDepartments[i].DepartmentNumber == id)
                {
                    
                    return lstDepartments[i];
                }
            }
            return null;
        }
        public int Insert(Department obj)
        {
            lstDepartments.Add(obj);
            return 1;
        }

        public int Update(Department obj)
        {
            Department c = GetById(obj.DepartmentNumber);
            if (c != null)
            {
                c.DepartmentNumber = obj.DepartmentNumber;
                return 1;
            }
            return 0;
        }
    }
}
