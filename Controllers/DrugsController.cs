﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugVerizone.Models;
using DrugVerizone.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugVerizone.Controllers
{
    public class DrugsController : Controller
    {
        private readonly IDrugsRepository _drugsRepository;

        public DrugsController(IDrugsRepository drugsRepository)
        {
            _drugsRepository = drugsRepository;
        }
        // GET: Drugs
        public async Task<IActionResult> Index()
        {
            var model = await _drugsRepository.Get();
            return View( model);
        }


         
        // GET: Drugs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || id.Value == Guid.Empty)
            {
                 return BadRequest();
            }
            var result = await _drugsRepository.ListById(id.Value);
            if(result == null)
            {
                return NotFound();

            }
                    return View(result);
        }

        // GET: Drugs/Create
        public async Task<IActionResult> Create()
        {
            // Get Manufacturer List
            List<ManufacturerViewDto> manList = new List<ManufacturerViewDto>();

            var man = await _drugsRepository.GetMan();
            manList = (from c in man select c).ToList();

            ViewBag.manList = manList;


            //Get Drug Type List
            List<DrugTypeViewDto> typeList = new List<DrugTypeViewDto>();

            var type = await _drugsRepository.GetDrugType();
            typeList = (from c in type select c).ToList();

            ViewBag.typeList = typeList;

            return View();
        }
       
        // POST: Drugs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<DrugsViewDto>> Create(DrugCreateDto model)
        {
            if (ModelState.IsValid)
            {
                await _drugsRepository.Create(model);

                return RedirectToAction(nameof(Index));
            }
           
                return View();
           
        }

        // GET: Drugs/Edit/5

        public async Task<ActionResult<DrugsViewDto>> Edit(Guid id)
        {
            var model = await _drugsRepository.ListById(id);

            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Drugs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Edit(Guid id, DrugUpdateDto drugUpdate)
        {
            try
            {

                await _drugsRepository.Update(id, drugUpdate);
                return RedirectToAction("Index");

              
            }
            catch(Exception ex)
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