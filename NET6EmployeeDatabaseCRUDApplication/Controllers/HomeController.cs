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

        public IActionResult EditEmployee()
        {
            int id = Convert.ToInt32(Request.Query["RowId"]);
            Employee data = dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
            if (data == null)
            {
                return NotFound();
            }
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("AddEmployee", data);

        }

        [HttpPost]
        public IActionResult EditEmployee(Employee model)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Department");
            ModelState.Remove("DepartmentId");
            if(ModelState.IsValid)
            {
                dbContext.Employees.Update(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("AddEmployee",model);
        }

        public IActionResult DeleteEmployee()
        {
            int id = Convert.ToInt32(Request.Query["RowId"]);
            Employee employee = dbContext.Employees.Where(e=>e.Id==id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
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