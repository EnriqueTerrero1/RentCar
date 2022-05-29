using Microsoft.AspNetCore.Mvc;
using RentCar.Models;
using RentCar.Models.Interface;

namespace RentCar.Controllers
{
    public class VehiculeController : Controller
    {
        private readonly RentCarDBcontext dbcontext;
        private readonly IRentCar<Vehicule> _vehicule;
        private readonly IRentCar<VehiculeModel> vehiculeModel;
        private readonly IRentCar<Brand> _brand;
        private readonly IRentCar<Vehicule_Type> _vehicule_Type;
        private readonly IRentCar<Fuel_Type> _fuel_Type;

       
        public VehiculeController(IRentCar<Vehicule> vehicule, IRentCar<VehiculeModel> _vehiculeModel, IRentCar<Brand> _brand, IRentCar<Vehicule_Type> _vehicule_Type, IRentCar<Fuel_Type> _fuel_Type)
        {
            this._vehicule=vehicule;
           this._brand = _brand;
            this._fuel_Type = _fuel_Type; ;
            this.vehiculeModel = _vehiculeModel;
            this._vehicule_Type = _vehicule_Type;
        }
        public IActionResult Index()
        {
            var _vehiculebrand = _brand.GetAll();
            var vehicule = _vehicule.GetAll();
            var _vehiculeType = _vehicule_Type.GetAll();
            var _fuelType = _fuel_Type.GetAll();
            var _vehiculeModel=vehiculeModel.GetAll();

            var types = new RentCarModelView
            {
              
                vehicules = vehicule,
                brands = _vehiculebrand,
                vehicule_Types = _vehiculeType,
                vehiculeModels = _vehiculeModel,
                fuel_Types = _fuelType
            };
            return View(types);
        }

        public async Task<IActionResult> Create(Vehicule vehicule, string vehicule_Type,string brand,string model,string fuel_Type)
        {
            vehicule.id = new Guid();
            vehicule.model = vehiculeModel.GetAll().Where(x => x.description == model).FirstOrDefault();
            vehicule.fuel_type = _fuel_Type.GetAll().Where(x => x.description == fuel_Type).FirstOrDefault();
            vehicule.brand = _brand.GetAll().Where(x => x.description == brand).FirstOrDefault();
            vehicule.vehicule_Type= _vehicule_Type.GetAll().Where(x => x.description == vehicule_Type).FirstOrDefault();
          
            var succesfull = await _vehicule.CreateAsync(vehicule);

            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            var succesfull = await _vehicule.DeleteAsync(id);
            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Vehicule vehicule, string description,string vehicule_Type, string brand, string model, string fuel_Type)
        {
            vehicule.description = description; 
            vehicule.model = vehiculeModel.GetAll().Where(x => x.description == model).FirstOrDefault();
            vehicule.fuel_type = _fuel_Type.GetAll().Where(x => x.description == fuel_Type).FirstOrDefault();
            vehicule.brand = _brand.GetAll().Where(x => x.description == brand).FirstOrDefault();
            vehicule.vehicule_Type = _vehicule_Type.GetAll().Where(x => x.description == vehicule_Type).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Index");
            }

            var succesfull = await _vehicule.UpdateAsync(vehicule);

            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
    }
}
