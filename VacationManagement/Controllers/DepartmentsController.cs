using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationManagement.Models;
using VacationManagement.Services;
using VacationManagement.ViewModels;

namespace VacationManagement.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ICrud<Department> departmentService;
        public DepartmentsController(ICrud<Department> departmentService)
        {
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var viewModel = new DepartmentsViewModel();
            viewModel.DomainList=departmentService.RetriveAll().OrderBy(x=>x.Name).ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new DepartmentsViewModel();
            viewModel.DomainModel = new ();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                departmentService.Insert(viewModel.DomainModel);
              return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public IActionResult Update(int? Id)
        {
            var viewModel = new DepartmentsViewModel();
            viewModel.DomainModel = departmentService.RetriveById(Id.GetValueOrDefault());
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Updete(DepartmentsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                departmentService.Update(viewModel.DomainModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int? Id)
        {
            var viewModel = new DepartmentsViewModel();
            viewModel.DomainModel = departmentService.RetriveById(Id.GetValueOrDefault());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DepartmentsViewModel viewModel)
        {
            if (viewModel.DomainModel != null)
            {
                departmentService.Delete(viewModel.DomainModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

    }
}
