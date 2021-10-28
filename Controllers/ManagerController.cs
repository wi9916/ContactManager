using ContactManager.Interfaces;
using ContactManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View(_managerServic.Get());
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var food = _managerServic.Get(id);
            if (food != null)
            {
                return View(food);
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
            return RedirectToAction(nameof(Index));
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _managerServic.Delete(id);
            _managerServic.Save();
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public IActionResult OnPostInsertCodeAsync(IFormFile upload)
        //{
        //    if (upload.FileName.EndsWith(".csv"))
        //    {
        //        using (var sreader = new StreamReader(upload.OpenReadStream()))
        //        {
        //            string[] headers = sreader.ReadLine().Split(',');     //Title
        //            while (!sreader.EndOfStream)                          //get all the content in rows 
        //            {
        //                string[] rows = sreader.ReadLine().Split(',');
        //                int Id = int.Parse(rows[0].ToString());
        //                int NUM = int.Parse(rows[1].ToString());
        //            }
        //        }
        //    }
        //    return View();
        //}
    }
}
