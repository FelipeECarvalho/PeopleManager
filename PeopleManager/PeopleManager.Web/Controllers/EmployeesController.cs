using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Application.Services;
using PeopleManager.Application.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController(IEmployeeService employeeService, IPersonService personService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var vm = new EmployeeViewModel();

            try
            {
                vm.Employees = await employeeService.GetAllAsync();
                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(vm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var vm = new EmployeeViewModel
                {
                    Employee = await employeeService.GetByIdAsync(id.Value)
                };

                if (vm.Employee == null)
                    return NotFound();

                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var vm = new EmployeeViewModel
                {
                    Persons = await personService.GetAllAsync()
                };

                if (vm.Persons == null || vm.Persons.Count == 0)
                    throw new Exception("Error! You have to register a person first.");

                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel vm)
        {
            try
            {
                await employeeService.SaveAsync(vm.Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(vm);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var vm = new EmployeeViewModel
                {
                    Employee = await employeeService.GetByIdAsync(id.Value),
                };

                if (vm.Employee == null)
                    return NotFound();

                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel vm)
        {
            try
            {
                await employeeService.UpdateAsync(vm.Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(vm);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var vm = new EmployeeViewModel
                {
                    Employee = await employeeService.GetByIdAsync(id.Value)
                };

                if (vm.Employee == null)
                    return NotFound();

                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var employee = await employeeService
                    .GetByIdAsync(id);

                if (employee != null)
                    await employeeService.DeleteAsync(employee);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Delete));
        }

        public async Task<JsonResult> GetByName()
        {
            var employeesList = await employeeService.GetByNameAsync(Request.Query["name"]);

            var data = employeesList?
                .Select(x => $"{x.Id} - {x.Person.Name} - {x.Department} - {x.Salary}");

            return Json(data);
        }
    }
}
