
using Microsoft.AspNetCore.Mvc;
using RentCar.Models;
using RentCar.Models.Interface;

namespace RentCar.Controllers
{

    
    public class ClientController : Controller
    {
        private readonly IRentCar<Client> _client;

        public ClientController(IRentCar<Client>client)
        {
            this._client = client;
        }
        public IActionResult Index()
        {
            var cl = new RentCarModelView
            {
                clients = _client.GetAll().ToArray(),
            };
            return View(cl);
        }
        public async Task<IActionResult> Create( Client client)
        {
            client.id= new Guid();
           await _client.CreateAsync(client);
            return RedirectToAction("index");

        }
        public async Task<IActionResult>Delete(Guid id)
        {
            await _client.DeleteAsync(id);
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Update(Client client)
        {
            await _client.UpdateAsync(client);
            return RedirectToAction("Index");

        }
        
    }
}
