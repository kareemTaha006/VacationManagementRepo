using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationManagement.Models;
using VacationManagement.Services;
using VacationManagement.ViewModels;

namespace VacationManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ICrud<Employee> Employeeervice;
        private readonly ICrud<Department> departmentService;
        public EmployeeController(ICrud<Employee> Employeeervice, ICrud<Department> departmentService)
        {
            this.Employeeervice = Employeeervice;
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var viewModel = new EmployeeViewModel();
            viewModel.DomainList=Employeeervice.RetriveAll().OrderBy(x=>x.Name).ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new EmployeeViewModel();
            viewModel.DomainModel = new ();
            viewModel.Departments = departmentService.RetriveAll();
   

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Employeeervice.Insert(viewModel.DomainModel);
              return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public IActionResult Update(int? Id)
        {
            var viewModel = new EmployeeViewModel();
            viewModel.DomainModel = Employeeervice.RetriveById(Id.GetValueOrDefault());
            viewModel.Departments = departmentService.RetriveAll();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Employeeervice.Update(viewModel.DomainModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int? Id)
        {
            var viewModel = new EmployeeViewModel();
            viewModel.DomainModel = Employeeervice.RetriveById(Id.GetValueOrDefault());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeViewModel viewModel)
        {
            if (viewModel.DomainModel != null)
            {
                Employeeervice.Delete(viewModel.DomainModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

    }
}
