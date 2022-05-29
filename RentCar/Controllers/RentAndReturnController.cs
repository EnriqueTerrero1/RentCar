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
        
        public RentAndReturnController(IRentCar<RentAndReturn> rentAndReturn,IRentCar<Employee> employee, IRentCar<Vehicule> vehicule, IRentCar<Client> client)
        {
            _employee = employee;
            _vehicule = vehicule;
            _client = client;
            _rentAndReturn=rentAndReturn;
        }
        public IActionResult Index()
        {
            var RentAndReturn = new RentCarModelView()
            {
                employees = _employee.GetAll().ToArray(),
                vehicules = _vehicule.GetAll().ToArray(),
                clients = _client.GetAll().ToArray(),
                rentAndReturns = _rentAndReturn.GetAll().ToArray(),
            };
            return View(RentAndReturn);
        }
    }
}
