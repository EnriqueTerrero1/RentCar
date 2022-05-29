using RentCar.Models.Interface;
using RentCar.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class Vehicule_ModelController : Controller
    {
        private readonly RentCarDBcontext dbcontext;
        private readonly IRentCar<VehiculeModel> _vehiculeModel;
        private readonly IRentCar<Brand> _brand;
        public Vehicule_ModelController(IRentCar<VehiculeModel> vehiculemodel, IRentCar<Brand> vehiculebrand)
        {
            this._vehiculeModel = vehiculemodel;
            this._brand = vehiculebrand;
        }
        // GET: Vehicule_TypeController
        public IActionResult Index()
        {
            var vehiculeModel = _vehiculeModel.GetAll();
            var vehiculebrand = _brand.GetAll();
           // var brand= dbcontext.brands.FirstOrDefault();
            var types = new RentCarModelView
            {
                vehiculeModels = vehiculeModel,
                brands= vehiculebrand
            };

            return View(types) ;
        }
        public async Task<IActionResult>Create(VehiculeModel vehiculeModel,string brand)


        {
            vehiculeModel.id = Guid.NewGuid();
          
             vehiculeModel.brand = _brand.GetAll().Where(x=> x.description ==brand).FirstOrDefault();
           /*if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }*/

            var succesfull = await _vehiculeModel.CreateAsync(vehiculeModel);
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
                return RedirectToAction("Index");
            }
            var succesfull = await _vehiculeModel.DeleteAsync(id);
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

        public async Task<IActionResult> UpdateAsync(VehiculeModel vehiculeModel, string brand)
        {
            vehiculeModel.brand = _brand.GetAll().Where(x => x.description == brand).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Index");
            }

            var succesfull = await _vehiculeModel.UpdateAsync(vehiculeModel);

            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
    }


}

