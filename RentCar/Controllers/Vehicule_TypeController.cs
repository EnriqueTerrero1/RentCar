using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Models;
using RentCar.Models.Interface;

namespace RentCar.Controllers
{
    public class Vehicule_TypeController : Controller


    {
        readonly IRentCar RentCar;
        public Vehicule_TypeController(IRentCar RentCar)
        {
            this.RentCar = RentCar;
        }
        // GET: Vehicule_TypeController
        public async Task<IActionResult> Index()
        {
            var vehicule_Types = await RentCar.GetAllAsync();
            var model = new RentCarModelView
            {
                vehicule_Types = vehicule_Types
            };

            return View(model);
        }


        public async Task<IActionResult> Create(Vehicule_Type vehicule_Type)
        {
            if (!ModelState.IsValid)
            {
                // return RedirectToAction("Vehicule_Type_AddView");
            }
            var succesfull = await RentCar.CreateAsync(vehicule_Type);
            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return View("Vehicule_Type_AddView");
        }

        public IActionResult AddVehicule_TypeView()
        {
            return View("Vehicule_Type_AddView");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Vehicule_Type_AddView");
            }
            var succesfull = await RentCar.DeleteAsync(id);
            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
        

    }


    }
