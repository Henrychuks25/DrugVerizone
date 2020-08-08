using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugVerizone.Models;
using DrugVerizone.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugVerizone.Controllers
{
    public class DrugTypeController : Controller
    {
        private readonly IDrugTypeRepository _drugsRepository;

        public DrugTypeController(IDrugTypeRepository drugsRepository)
        {
            _drugsRepository = drugsRepository;
        }
        // GET: Drugs
        public async Task<IActionResult> Index()
        {
            var model = await _drugsRepository.Get();
            return View(model);
        }



        // GET: Drugs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || id.Value == Guid.Empty)
            {
                return BadRequest();
            }
            var result = await _drugsRepository.ListById(id.Value);
            if (result == null)
            {
                return NotFound();

            }
            return View(result);
        }

        // GET: Drugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drugs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<DrugTypeViewDto>> Create(DrugTypeCreateDto model)
        {
            if (ModelState.IsValid)
            {
                await _drugsRepository.Create(model);

                return RedirectToAction(nameof(Index));
            }

            return View();

        }

        // GET: Drugs/Edit/5

        public async Task<ActionResult<DrugTypeViewDto>> Edit(Guid id)
        {
            var model = await _drugsRepository.ListById(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Drugs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, DrugTypeUpdateDto drugUpdate)
        {
            try
            {

                await _drugsRepository.Update(id, drugUpdate);
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return View();
        }

        // GET: Drugs/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (_drugsRepository.DrugExist(id).Result)
            {
                return NotFound();
            }
            _drugsRepository.Delete(id);
            return View();
        }

        // POST: Drugs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}