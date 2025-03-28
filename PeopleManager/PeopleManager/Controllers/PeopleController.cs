using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Application.Services;
using PeopleManager.Domain.Entities;

namespace PeopleManager.Api.Controllers
{
    public class PeopleController(PersonService _personService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _personService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _personService.GetByIdAsync(id.Value);

            if (person == null)
                return NotFound();

            return View(person);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                await _personService.SaveAsync(person);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _personService.GetByIdAsync(id.Value);

            if (person == null)
                return NotFound();

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            if (id != person.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                try
                {
                    await _personService.UpdateAsync(person);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PersonExists(person.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }
            
            return View(person);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _personService.GetByIdAsync(id.Value);

            if (person == null)
                return NotFound();

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _personService.GetByIdAsync(id);

            if (person != null)
                await _personService.DeleteAsync(person);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PersonExists(int id)
        {
            return await _personService.ExistsAsync(id);
        }
    }
}
