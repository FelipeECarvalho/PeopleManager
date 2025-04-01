using Microsoft.AspNetCore.Mvc;
using PeopleManager.Application.Services;
using PeopleManager.Core.Entities;
using System;
using System.Threading.Tasks;

namespace PeopleManager.Web.Controllers
{
    public class PeopleController(IPersonService _personService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _personService.GetAllAsync());
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var person = await _personService.GetByIdAsync(id.Value);

                if (person == null)
                    return NotFound();

                return View(person);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _personService.SaveAsync(person);
                    return RedirectToAction(nameof(Index));
                }

                return View(person);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var person = await _personService.GetByIdAsync(id.Value);

                if (person == null)
                    return NotFound();

                return View(person);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            try
            {
                if (id != person.Id)
                    return NotFound();

                if (!ModelState.IsValid)
                    return View(person);

                await _personService.UpdateAsync(person);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var person = await _personService.GetByIdAsync(id.Value);

                if (person == null)
                    return NotFound();

                return View(person);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var person = await _personService.GetByIdAsync(id);

                if (person != null)
                    await _personService.DeleteAsync(person);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction();
            }
        }

        private async Task<bool> PersonExists(int id)
        {
            return await _personService.ExistsAsync(id);
        }
    }
}
