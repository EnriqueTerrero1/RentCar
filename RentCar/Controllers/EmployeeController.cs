using Microsoft.AspNetCore.Mvc;
using RentCar.Models;
using RentCar.Models.Interface;

namespace RentCar.Controllers
{
    public class EmployeeController : Controller
    {
       
            private readonly IRentCar<Employee> _employee;

            public EmployeeController(IRentCar<Employee> _employee)
            {
                this._employee = _employee;
            }
            public IActionResult Index()
            {
                var cl = new RentCarModelView
                {
                    employees = _employee.GetAll().ToArray(),
                };
                return View(cl);
            }
            public async Task<IActionResult> Create(Employee employee)
            {
                employee.id = new Guid();
                await _employee.CreateAsync(employee);
                return RedirectToAction("index");

            }
            public async Task<IActionResult> Delete(Guid id)
            {
                await _employee.DeleteAsync(id);
                return RedirectToAction("index");
            }
            public async Task<IActionResult> Update(Employee employee)
            {
                await _employee.UpdateAsync(employee);
                return RedirectToAction("Index");

            }
        }
}
