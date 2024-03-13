using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationManagement.Models;
using VacationManagement.Services;
using VacationManagement.ViewModels;

namespace VacationManagement.Controllers
{
    public class VacationTypeController : Controller
    {
        private readonly ICrud<VacationType> vacationTypeService;

        public VacationTypeController(ICrud<VacationType> VacationTypeService)
        {
            this.vacationTypeService = VacationTypeService;
        }
        public IActionResult Index()
        {
            var viewModel = new VacationTypeViewModel();
            viewModel.DomainList=vacationTypeService.RetriveAll().OrderBy(x=>x.VactionName).ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new VacationTypeViewModel();
            viewModel.DomainModel = new ();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VacationTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                vacationTypeService.Insert(viewModel.DomainModel);
              return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public IActionResult Update(int? Id)
        {
            var viewModel = new VacationTypeViewModel();
            viewModel.DomainModel = vacationTypeService.RetriveById(Id.GetValueOrDefault());
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(VacationTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                vacationTypeService.Update(viewModel.DomainModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int? Id)
        {
            var viewModel = new VacationTypeViewModel();
            viewModel.DomainModel = vacationTypeService.RetriveById(Id.GetValueOrDefault());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(VacationTypeViewModel viewModel)
        {
            if (viewModel.DomainModel != null)
            {
                vacationTypeService.Delete(viewModel.DomainModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

    }
}
