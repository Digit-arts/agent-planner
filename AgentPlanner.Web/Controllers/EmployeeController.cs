using System.Web.Http;
using AgentPlanner.BindingModels.Employee;
using AgentPlanner.BindingModels.Mappers;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Employee;
using AgentPlanner.ViewModels.Mappers;
using AgentPlanner.Web.Models;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : BaseController
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        // GET: api/employee/list/{pageSize}/{pageNumber}
        [HttpGet]
        [Route("list/{pageSize:int}/{pageNumber:int}")]
        public EmployeeListViewModel Get(int pageSize, int pageNumber)
        {
            return new EmployeeListViewModel
            {
                Employees = _employeeService.GetPaginatedEmployees(pageSize, pageNumber).ToVms(Utility.SiteUrl),
                EmployeeCount = _employeeService.GetTotalEmployeesCount()
            };
        }
        
        // GET: api/employee/5
        [Route("{id:int}")]
        [HttpGet]
        public EmployeeViewModel Get(int id)
        {
            return _employeeService.GetEmployee(id).ToVm(Utility.SiteUrl);
        }

        [HttpPost]
        [Route("search")]
        public EmployeeViewModel[] Search(int siteId, string searchTerm)
        {
            return _employeeService.SearchEmployees(siteId, searchTerm).ToVms();
        }

        // POST: api/employee
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(EmployeeBindingModel employee)
        {
            var employeeId = _employeeService.AddEmployee(employee.ToDto());
            return Ok(employeeId);
        }

        // PUT: api/Employee/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, EmployeeBindingModel employee)
        {
            return Ok(_employeeService.UpdateEmployee(id, employee.ToDto()));
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_employeeService.DeleteEmployee(id));
        }

        [HttpGet]
        [Route("codecheck/{code}")]
        public bool CodeCheck(string code)
        {
            return _employeeService.CheckEmployeeCode(code);
        }
    }
}
