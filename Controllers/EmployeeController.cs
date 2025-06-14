using employeemvcapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employeemvcapp.Controllers;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _db;
    public EmployeeController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        var Employees = _db.Employees.Include(c=>c.Salaries).ToList();
        return View(Employees);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ActionName("Create")]
    public IActionResult CreateEmployee(Employee employee)
    {
        if (ModelState.IsValid)
        {
            employee.CreatedDate = DateTime.Now;
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }


    [HttpGet]
    [ActionName("AddMonthlySalary")]
    public IActionResult AddMonthlySalary(int id)
    {
        var employee = _db.Employees.Where(x => x.id == id).Include(c => c.Salaries).FirstOrDefault();
        EmployeeSalary employeeSalary = new EmployeeSalary
        {
            EmployeeId = id,
            Employee = employee,
            Amount = employee.Salaries != null && employee.Salaries.Any()
             ? employee.Salaries.First().Amount
             : 0,
            SalaryDate = DateTime.Today
        };
        return View(employeeSalary);
    }

    [HttpPost]
    public IActionResult AddMonthlySalary(EmployeeSalary empSalary)
    {
        if (empSalary != null)
        {
            EmployeeSalary newEmpSalary = new EmployeeSalary
            {
                EmployeeId = empSalary.EmployeeId,
                SalaryDate = empSalary.SalaryDate,
                Amount = empSalary.Amount,
                CreatedDate = DateTime.UtcNow
            };
            _db.EmployeeSalaries.Add(newEmpSalary);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
            return NotFound();

    }
    [HttpPost]
    public IActionResult EditEmployee(Employee updatedEmp)
    {
        var employee = _db.Employees.FirstOrDefault(e => e.id == updatedEmp.id);
            var Employees = _db.Employees.ToList();
        if (employee != null)
        {
            employee.FirstName = updatedEmp.FirstName;
            employee.LastName = updatedEmp.LastName;
            employee.City = updatedEmp.City;
            employee.Zip = updatedEmp.Zip;

            _db.SaveChanges();
            return RedirectToAction("Index",Employees);
        }
    
        return View("Index", Employees);
    }
}