using Microsoft.EntityFrameworkCore;
using VacationManagement.Data;
using VacationManagement.Models;

namespace VacationManagement.Services
{
    public class DepartmentService : ICrud<Department>
    {
        private readonly VacationDbContext context;
        public DepartmentService(VacationDbContext _context)
        {
            this.context = _context;
        }
        public void Delete(Department entity)
        {
            context.Departments.Remove(entity);
            context.SaveChanges();
        }

        public void Insert(Department entity)
        {
            context.Departments.Add(entity);
            context.SaveChanges();
        }

        public List<Department> RetriveAll()
        {
            return context.Departments.ToList();
        }

        public Department RetriveById(int id)
        {
            return context.Departments.FirstOrDefault(x=>x.Id == id);
        }

        public void Update(Department entity)
        {
            context.Departments.Update(entity);
            context.SaveChanges();
        }
    }
}
