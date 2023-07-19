using Microsoft.AspNetCore.Mvc;
using NET6EmployeeDatabaseCRUDApplication.Models;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace NET6EmployeeDatabaseCRUDApplication.Controllers
{

    public class HomeController : Controller
    {
        HRDatabaseContext dbContext = new HRDatabaseContext();
        
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment _hosting;
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hosting)
        {
            _logger = logger;
            _hosting = hosting;
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
                string fileName = string.Empty;
                if (model.ClientFile != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, "Images");
                    fileName = model.ClientFile.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    model.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    model.ImagePath = fileName;
                    TempData["Image"] = "Ok";
                }
                

                TempData["EmployeeAdded"] = "Success";
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
            ModelState.Remove("DepartmentName");
            if(ModelState.IsValid)
            {
                TempData["EmployeeUpdating"] = "Success";
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
            TempData["EmployeeDeleted"] = "Success";
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction("ShowEmployeeData");
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