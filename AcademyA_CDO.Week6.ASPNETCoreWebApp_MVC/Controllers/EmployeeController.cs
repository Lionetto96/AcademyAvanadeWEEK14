using AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Helpers;
using AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Models;
using AcademyA_CDO.Week6.Core.Interfaces;
using AcademyA_CDO.Week6.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMainBusinessLayer mainBL;

        public EmployeeController(IMainBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }

        // This is an *action*, it needs to have also an associated view
        public IActionResult Index()
        {
            var result = mainBL.FetchEmployees();
            var model = result.ToListViewModel();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
                return View();

            var employee = mainBL.GetEmployeeById(id);
            var model = employee.ToDetailsViewModel();

            return View(model);
        }

        // HTTP GET /employee/create
        public IActionResult Create()
        {
            EmployeeEditViewModel model = new EmployeeEditViewModel
            {
                AvailableLevels = GetAvailableLevels()
            };

            return View(model);
        }

        // HTTP POST /employee/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create(IFormCollection collection)
        public IActionResult Create(EmployeeEditViewModel model)  // MODEL BINDING
        {
            if (!ModelState.IsValid)
            {
                model.AvailableLevels = GetAvailableLevels();
                return View(model);
            }

            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "Error Generating model.");
                model.AvailableLevels = GetAvailableLevels();
                return View(model);
            }

            // chiamata al BL ...
            Employee newEmployee = model.ToEmployee();
            var result = this.mainBL.AddNewEmployee(newEmployee);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, $"Error saving data: {result.Message}");
                model.AvailableLevels = GetAvailableLevels();
                return View(model);
            } // in caso di errore

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View();

            // chiamata a BL ...
            Employee data = this.mainBL.GetEmployeeById(id);
            EmployeeEditViewModel model = data.ToEditViewModel();
            model.AvailableLevels = GetAvailableLevels();

            return View(model);
        }

        // POST: EmployeeRWController/Edit/5
        [HttpPost]
        // con questo attributo viene aggiunto in automatico nella form un campo hidden
        // con il Request Validation Token per prevenire attacchi crosssite
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Adm")] // solo l'admin puo' modificare un utente
        public IActionResult Edit(int id, EmployeeEditViewModel model)
        {
            if (id != model.Id)
            {
                ModelState.AddModelError(string.Empty, "Employee IDs do not match.");
                model.AvailableLevels = GetAvailableLevels();
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.AvailableLevels = GetAvailableLevels();
                return View(model);
            }

            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "Error Generating model.");
                model.AvailableLevels = GetAvailableLevels();
                return View(model);
            }

            // chiamata al BL ...


            Employee updatedEmployee = model.ToEmployee();
            var result = this.mainBL.UpdateEmployee(updatedEmployee);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, $"Error saving updated data: {result.Message}");
                model.AvailableLevels = GetAvailableLevels();
                return View(model);
            } // in caso di errore

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return View();

            // chiamata a BL ...
            Employee data = this.mainBL.GetEmployeeById(id);
            EmployeeDetailsViewModel model = data.ToDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (id <= 0)
                return View();

            // chiamata al BL ...
            var result = this.mainBL.DeleteEmployeeById(id);

            if (!result.Success)
            {
                return View("Error", null);
            } // in caso di errore

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteJS(int id)
        {
            if (id <= 0)
                return Json(false);

            // chiamate al BL ...
            var result = this.mainBL.DeleteEmployeeById(id);

            return Json(result.Success);
        }
        #region Support Methods

        [NonAction]
        private List<SelectListItem> GetAvailableLevels()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem { Text = "Manager (lvl 1)", Value = "Manager" },
                new SelectListItem { Text = "Supervisor (lvl 2)", Value = "Supervisor" },
                new SelectListItem { Text = "Dev (lvl 99)", Value = "Dev" }
            };
        }

        #endregion
    }
}
