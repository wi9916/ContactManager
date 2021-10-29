using ContactManager.Interfaces;
using ContactManager.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerServic;
        public ManagerController(IManagerService managerServic)
        {
            _managerServic = managerServic;

            //using (var writer = new StreamWriter("\\file.csv"))
            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecords(_managerServic.Get());
            //}

            //var obj = new Manager()
            //{
            //    Name = "Oleg",
            //    Married = true,
            //    Phone = "+3405556667585",
            //    Salary = 232
            //};
            //_managerServic.Add(obj);
            //_managerServic.Save();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormFile file)
        {
            if (file == null || Path.GetExtension(file.FileName) != ".csv")
                return View();

            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Manager>();

                foreach (var rec in records)
                    _managerServic.Add(rec);

                _managerServic.Save();
            }

            return RedirectToAction("Managers");
        } 
        
        [HttpGet]
        public IActionResult Managers()
        {
            return View(_managerServic.Get());
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var manager = _managerServic.Get(id);
            if (manager != null)
            {
                return View(manager);
            }

            return NotFound();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manager manager)
        {
            if (!ModelState.IsValid)
                return View(manager);

            _managerServic.Add(manager);
            _managerServic.Save();
            return RedirectToAction("Managers");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var manager = _managerServic.Get(id);
            if (manager != null)
                return View(manager);

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manager manager)
        {
            if (!ModelState.IsValid)
                return View(manager);

            _managerServic.Edit(manager);
            return RedirectToAction("Managers");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _managerServic.Delete(id);
            _managerServic.Save();
            return RedirectToAction("Managers");
        }
    }
}
