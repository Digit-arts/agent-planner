using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Employee;
using AgentPlanner.ViewModels.Mappers;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/employeeType")]
    public class EmployeeTypeController : BaseController
    {
        private readonly EmployeeTypeService _employeeTypeService;

        public EmployeeTypeController()
        {
            _employeeTypeService = new EmployeeTypeService();
        }

        [Route("all")]
        [HttpGet]
        public EmployeeTypeViewModel[] GetAllEmployeeTypes()
        {
            return _employeeTypeService.GetAllEmployeeTypes().ToVms().ToArray();
        }
    }
}
