using Microsoft.AspNetCore.Mvc;
using RentCar.Models.Interface;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class Fuel_TypeController : Controller
    {

        private readonly RentCarDBcontext dbcontext;
        private readonly IRentCar<Fuel_Type> _fuel_Type;

        public Fuel_TypeController(IRentCar<Fuel_Type> fuel_Type)
        {
            _fuel_Type = fuel_Type;
        }

        public IActionResult Index()
        {
            var fuel_Types = _fuel_Type.GetAll();
            var fuel_type = new RentCarModelView
            {
                fuel_Types = fuel_Types
        };

            return View(fuel_type);
        }

        public async Task<IActionResult>Create(Fuel_Type fuel_Type)
        {
            fuel_Type.Id= Guid.NewGuid();
            var succesfull = await _fuel_Type.CreateAsync(fuel_Type);
           return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var succesfull = await _fuel_Type.DeleteAsync(id);
            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateAsync(Fuel_Type fuel_Type)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Index");
            }

            var succesfull = await _fuel_Type.UpdateAsync(fuel_Type);

            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
    }
}
