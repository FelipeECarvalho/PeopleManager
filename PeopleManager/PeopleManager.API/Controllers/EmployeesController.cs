﻿using Microsoft.AspNetCore.Mvc;
using PeopleManager.API.Models;
using PeopleManager.Application.Services;
using System;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace PeopleManager.API.Controllers
{
    public class EmployeesController(EmployeeService employeeService, PersonService personService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                var vm = new EmployeeViewModel
                {
                    Employees = await employeeService.GetAllAsync()
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(new EmployeeViewModel());
            }
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
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
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
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel vm)
        {
            try
            {
                if (!vm.PersonId.HasValue)
                    throw new Exception("Employee is invalid.");

                vm.Employee.Person = await personService.GetByIdAsync(vm.PersonId.Value);
                
                await employeeService.SaveAsync(vm.Employee);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
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
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel vm)
        {
            try
            {
                if (id != vm.Employee.Id)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    try
                    {
                        await employeeService.UpdateAsync(vm.Employee);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await EmployeeExists(vm.Employee.Id))
                            return NotFound();
                        else
                            throw;
                    }

                    return RedirectToAction(nameof(Index));
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(vm);
            }
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

                return View(vm.Employee);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
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
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Delete));
            }
        }

        private async Task<bool> EmployeeExists(int id)
        {
            return await employeeService.ExistsAsync(id);
        }
    }
}
