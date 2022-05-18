using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
       private  EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

    [HttpGet("GetEmployee")]
        public List<EmployeeE> GetDepartment()
        {
            return employeeService.GetEmployee();

        }

    [HttpPost("Insert")]
        public int Insert(Employee employee)
        {
            return employeeService.Insert(employee);
        }


    [HttpPut("Update")]
        public int Update(Employee employee, int Id)
        {
            return employeeService.Update(employee, Id);
        }

    }
}
