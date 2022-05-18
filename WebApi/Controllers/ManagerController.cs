using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private ManagerService managerService;

        public ManagerController(ManagerService managerService)
        {
            this.managerService = managerService;
        }

        [HttpGet("GetDepartmentManager")]
        public List<DepartmentManager> GetDepartmentManager()
        {
            return managerService.GetDepartmentManager();
        }

        [HttpPost("ManagerInsert")]
        public int ManagerInsert(DepartmentDM manager)
        {
            return managerService.ManagerInsert(manager);
        }
    }
}
