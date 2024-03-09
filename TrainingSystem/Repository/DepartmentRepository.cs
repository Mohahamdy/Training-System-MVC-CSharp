using Microsoft.EntityFrameworkCore;
using TrainingSystem.Models;

namespace TrainingSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        TrainingSystemContext context;
        public DepartmentRepository(TrainingSystemContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.Remove(GetById(id));
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Department department)
        {
            context.Add(department);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Department department)
        {
            context.Update(department);
        }
    }
}
