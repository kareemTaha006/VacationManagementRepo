using Microsoft.EntityFrameworkCore;
using VacationManagement.Data;
using VacationManagement.Models;

namespace VacationManagement.Services
{
    public class EmployeeService : ICrud<Employee>
    {
        private readonly VacationDbContext context;
        public EmployeeService(VacationDbContext _context)
        {
            this.context = _context;
        }
        public void Delete(Employee entity)
        {
            context.Employees.Remove(entity);
            context.SaveChanges();
        }

        public void Insert(Employee entity)
        {
            context.Employees.Add(entity);
            context.SaveChanges();
        }

        public List<Employee> RetriveAll()
        {
            return context.Employees.Include(x => x.Department).ToList();
        }

        public Employee RetriveById(int id)
        {
            return context.Employees.Include(x => x.Department).FirstOrDefault(x=>x.Id == id);
        }

        public void Update(Employee entity)
        {
            context.Employees.Update(entity);
            context.SaveChanges();
        }
    }
}
