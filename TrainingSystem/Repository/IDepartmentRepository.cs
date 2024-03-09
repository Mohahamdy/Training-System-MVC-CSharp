using TrainingSystem.Models;

namespace TrainingSystem.Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Insert(Department department);
        public void Update(Department department);
        public void Delete(int id);
        public int Save();
    }
}
