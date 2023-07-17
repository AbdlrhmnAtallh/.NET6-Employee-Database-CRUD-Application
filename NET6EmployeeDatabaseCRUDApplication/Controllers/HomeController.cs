using Microsoft.AspNetCore.Mvc;
using NET6EmployeeDatabaseCRUDApplication.Models;
using System.Diagnostics;

namespace NET6EmployeeDatabaseCRUDApplication.Controllers
{
    public class HomeController : Controller
    {
        HRDatabaseContext dbContext = new HRDatabaseContext();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View ();
            
        }
        public IActionResult AddEmployee()
        {
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee model)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Department");
            ModelState.Remove("DepartmentName");
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View();
                
        }

        public IActionResult ShowEmployeeData()
        {
            var employee = this.dbContext.Employees.ToList();
            return View(employee);
        }



        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}