using System.Diagnostics;
using MasGlobal.Domain.Contracts;
using MasGlobal.Dto;
using MasGLobal.Model;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interface;

namespace MasGLobalWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmployeeDomain _employeeDomain;

        public HomeController(IEmployeeDomain employeeDomain)
        {
            _employeeDomain = employeeDomain;
        }

        public ViewResult Details(int? id)
        {
            var model = _employeeDomain.GetEmployee(id.Value);
            if (model != null)
            {
                return View(model);
            }

            return View("NotFound");

        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(EmployeeDto employee)
        {
            if (employee.Id == 0)
            {
                var model = _employeeDomain.GetAllEmployees();
                return View(model);
            }

            return RedirectToAction("Details", new { id = employee.Id });
        }
       

        

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
