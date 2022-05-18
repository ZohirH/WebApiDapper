using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private DepartmentService departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }


        [HttpGet("GetDepartment")]
        public List<DepartmentD> GetDepartment()
        {
            return departmentService.GetDepartment();

        }

        [HttpPost("Insert")]
        public int Insert(Department department)
        {
            return departmentService.Insert(department);
        }
      
        [HttpPut("Update")]
        public int Update(Department department, int Id)
        {
            return departmentService.Update(department, Id);
        }

    }
}
