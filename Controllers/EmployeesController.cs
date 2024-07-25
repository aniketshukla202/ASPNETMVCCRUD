using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDBContext _mvcDemoDbContext;

        public EmployeesController(MVCDemoDBContext mvcDemoDbContext)
        {
            _mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeesViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateofBirth = addEmployeeRequest.DateofBirth
            };

            await _mvcDemoDbContext.Employees.AddAsync(employee);
            await _mvcDemoDbContext.SaveChangesAsync();

            return RedirectToAction("Add");
        }
    }
}
