using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentCar.Controllers
{
    public class Vehicule_TypeController : Controller
    {
        // GET: Vehicule_TypeController
        public ActionResult Index()
        {
            return View("");
        }

        // GET: Vehicule_TypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehicule_TypeController/Create
        public ActionResult Create()
        {
            return View("Vehicule_Type_AddView");
        }

        // POST: Vehicule_TypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicule_TypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vehicule_TypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicule_TypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vehicule_TypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
