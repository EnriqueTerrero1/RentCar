using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Models;
using RentCar.Models.Interface;
using RentCar.Models.Service;

namespace RentCar.Controllers
{
    public class Vehicule_TypeController : Controller


    {
        private readonly RentCarDBcontext dbcontext;
        private readonly IRentCar<Vehicule_Type> _vehicule_Type;
        public Vehicule_TypeController(IRentCar<Vehicule_Type> vehicule_Type)
        {
            _vehicule_Type = vehicule_Type;
        }
        // GET: Vehicule_TypeController
        public IActionResult Index()
        {
           var vehicule_Types= _vehicule_Type.GetAll();
            var types = new RentCarModelView
            {
                vehicule_Types = vehicule_Types
            };
            return View(types);
        }

        public async Task<IActionResult> Create(Vehicule_Type vehicule_Type)
        {
            if (!ModelState.IsValid)
            {
                 return RedirectToAction("Index");
            }
            
            var succesfull = await _vehicule_Type.CreateAsync(vehicule_Type);
            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Vehicule_Type_AddView");
            }
            var succesfull = await _vehicule_Type.DeleteAsync(id);
            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }

             public IActionResult AddVehicule_TypeView()
             {
                 return View("Vehicule_Type_AddView");
             }

        public async Task<IActionResult> UpdateAsync(Vehicule_Type vehicule_Type)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Index");
            }

            var succesfull = await _vehicule_Type.UpdateAsync(vehicule_Type);
            
            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
    }
           


        }


    
