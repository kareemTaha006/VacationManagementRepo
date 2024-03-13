using Microsoft.EntityFrameworkCore;
using VacationManagement.Data;
using VacationManagement.Models;

namespace VacationManagement.Services
{
    public class VacationTypeService : ICrud<VacationType>
    {
        private readonly VacationDbContext context;
        public VacationTypeService(VacationDbContext _context)
        {
            this.context = _context;
        }
        public void Delete(VacationType entity)
        {
            context.VacationTypes.Remove(entity);
            context.SaveChanges();
        }

        public void Insert(VacationType entity)
        {
            context.VacationTypes.Add(entity);
            context.SaveChanges();
        }

        public List<VacationType> RetriveAll()
        {
            return context.VacationTypes.ToList();
        }

        public VacationType RetriveById(int id)
        {
            return context.VacationTypes.FirstOrDefault(x=>x.Id == id);
        }

        public void Update(VacationType entity)
        {
            context.VacationTypes.Update(entity);
            context.SaveChanges();
        }
    }
}
