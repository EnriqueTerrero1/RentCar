using Microsoft.AspNetCore.Mvc;
using RentCar.Models.Interface;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class BrandController : Controller
    {

        private readonly RentCarDBcontext dbcontext;
        private readonly IRentCar<Brand> _brand;

        public BrandController(IRentCar<Brand> brand)
        {
            _brand = brand;
        }

        public IActionResult Index()
        {
            var brands = _brand.GetAll();
            var brand = new RentCarModelView
            {
                brands = brands
            };

            return View(brand);
        }

        public async Task<IActionResult> Create(Brand brand)
        {
            brand.id = Guid.NewGuid();
            var succesfull = await _brand.CreateAsync(brand);
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var succesfull = await _brand.DeleteAsync(id);
            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateAsync(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Index");
            }

            var succesfull = await _brand.UpdateAsync(brand);

            if (!succesfull)
            {
                return BadRequest("operacion fallida");
            }
            return RedirectToAction("Index");
        }
    }
}
