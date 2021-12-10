using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Repository
{
    public interface IRepository<T> where T : class
    {
        int Insert(T obj);
        int Update(T obj);
        int Delete(int id);
        List<T> GetAll();
        T GetById(int id);

    }
}
