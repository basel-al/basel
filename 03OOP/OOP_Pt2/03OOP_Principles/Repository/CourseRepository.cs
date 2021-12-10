
namespace _03OOP_Principles.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        List<Course> lstCourses = new List<Course>();
        public int Delete(int id)
        {
            Course c = GetById(id);
            if (c != null)
            {
                lstCourses.Remove(c);
                return 1;
            }
            return 0;
        }
        public List<Course> GetAll()
        {
            return lstCourses;
        }
        public Course GetById(int id)
        {
            for (int i = 0; i < lstCourses.Count; i++)
            {
                if (lstCourses[i].Coursenumber == id)
                {
                    return lstCourses[i];
                }
            }
            return null;
        }
        public int Insert(Course obj)
        {
            lstCourses.Add(obj);
            return 1;
        }

        public int Update(Course obj)
        {
            Course c = GetById(obj.Coursenumber);
            if (c != null)
            {
                c.Coursenumber = obj.Coursenumber;
                return 1;
            }
            return 0;
        }
    }
}
