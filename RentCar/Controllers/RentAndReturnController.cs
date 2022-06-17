using Microsoft.AspNetCore.Mvc;
using RentCar.Models;
using RentCar.Models.Interface;

namespace RentCar.Controllers
{
    public class RentAndReturnController : Controller
    {
        private readonly IRentCar<Employee> _employee;
        private readonly IRentCar<Vehicule> _vehicule;
        private readonly IRentCar<Client> _client;
        private readonly IRentCar<RentAndReturn> _rentAndReturn;
        private readonly IRentCar<VehiculeModel> vehiculeModel;
        private readonly IRentCar<Brand> _brand;
        private readonly IRentCar<Vehicule_Type> _vehicule_Type;
        private readonly IRentCar<Fuel_Type> _fuel_Type;
        private readonly RentCarDBcontext dbcontext;

        public RentAndReturnController(IRentCar<RentAndReturn> rentAndReturn,IRentCar<Employee> employee, IRentCar<Vehicule> vehicule, IRentCar<Client> client, IRentCar<VehiculeModel> _vehiculeModel, IRentCar<Brand> _brand, IRentCar<Vehicule_Type> _vehicule_Type, IRentCar<Fuel_Type> _fuel_Type)
        {
            _employee = employee;
            _vehicule = vehicule;
            _client = client;
            _rentAndReturn=rentAndReturn;
            vehiculeModel = _vehiculeModel;
           this._brand = _brand;
           this. _vehicule_Type = _vehicule_Type;
            this._fuel_Type = _fuel_Type;
        }
        public IActionResult Index()
        {
            
            var RentAndReturn = new RentCarModelView()
            {
                employees = _employee.GetAll().ToArray(),
                vehicules = _vehicule.GetAll().ToArray(),
                clients = _client.GetAll().ToArray(),
                rentAndReturns = _rentAndReturn.GetAll().ToArray(),
                
                brands = _brand.GetAll().ToArray(),
                vehicule_Types = _vehicule_Type.GetAll().ToArray(),
                vehiculeModels =vehiculeModel.GetAll().ToArray(),
                fuel_Types = _fuel_Type.GetAll().ToArray(),
            };
            return View(RentAndReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create( RentAndReturn rentAndReturn,Guid employee,Guid vehicule,Guid client)
        {
           // if (!ModelState.IsValid)
           // {
            //    return (rentAndReturn);
           // }
            rentAndReturn.Employee= _employee.GetAll().Where( x=> x.id == employee ).FirstOrDefault();
            rentAndReturn.Vehicule = _vehicule.GetAll().Where(x => x.id == vehicule).FirstOrDefault();
            rentAndReturn.client=_client.GetAll().Where(x=> x.id == client).FirstOrDefault();

            var succesfull = await _rentAndReturn.CreateAsync(rentAndReturn);


            return RedirectToAction("index");
        }

       
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _rentAndReturn.DeleteAsync(id);

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Update(Guid id,RentAndReturn rentAndReturn, Guid employee, Guid vehicule, Guid client)
        {
            rentAndReturn.Employee = _employee.GetAll().Where(x => x.id == employee).FirstOrDefault();
            rentAndReturn.Vehicule = _vehicule.GetAll().Where(x => x.id == vehicule).FirstOrDefault();
            rentAndReturn.client = _client.GetAll().Where(x => x.id == client).FirstOrDefault();

            //if (!ModelState.IsValid)
            //{
              //  return RedirectToAction("Index");
            //}

            var succesfull = await _rentAndReturn.UpdateAsync(rentAndReturn);

            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }

    }
}
