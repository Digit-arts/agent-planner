using System;
using System.Web.Http;
using AgentPlanner.BindingModels.Assignment;
using AgentPlanner.BindingModels.Mappers;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Assignment;
using AgentPlanner.ViewModels.Mappers;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/assignment")]
    public class AssignmentController : BaseController
    {
        private readonly AssignmentService _assignmentService;

        public AssignmentController()
        {
            _assignmentService = new AssignmentService();
        }

        [HttpGet]
        [Route("list/{contractId:int}/{pageSize:int}/{pageNumber:int}")]
        public AssignmentViewModelList Assignments(int contractId, int pageSize, int pageNumber)
        {
            return new AssignmentViewModelList
            {
                Assignments = _assignmentService.GetByContractId(contractId, pageSize, pageNumber).ToVms(),
                AssignmentCount = _assignmentService.GetTotalAssignmentsCount(contractId)
            };
        }

        [HttpGet]
        [Route("list")]
        public AssignmentViewModel[] Assignments(DateTime startDate, DateTime endDate)
        {
            return _assignmentService.GetAssignmentsByDates(startDate, endDate).ToVms();
        }

        [HttpGet]
        [Route("list/employee/{employeeId:int}")]
        public AssignmentViewModel[] GetAssignmentsByEmployeeId(int employeeId, DateTime startDate, DateTime endDate)
        {
            return _assignmentService.GetAssignmentsByEmployeeId(employeeId, startDate, endDate).ToVms();
        }

        [HttpGet]
        [Route("list/contract/{contractId:int}")]
        public AssignmentViewModel[] GetAssignmentsByContractId(int contractId, DateTime startDate, DateTime endDate)
        {
            return _assignmentService.GetAssignmentsByContractId(contractId, startDate, endDate).ToVms();
        }

        [HttpGet]
        [Route("list/client/{clientId:int}")]
        public AssignmentViewModel[] GetAssignmentsByClientId(int clientId, DateTime startDate, DateTime endDate)
        {
            return _assignmentService.GetAssignmentsByClientId(clientId, startDate, endDate).ToVms();
        }

        // GET: api/Assignment/5
        [HttpGet]
        [Route("{id:int}")]
        public AssignmentViewModel Get(int id)
        {
            return _assignmentService.GetAssignment(id).ToVm();
        }

        // POST: api/Assignment
        [HttpPost]
        [Route("")]
        public int Post(AssignmentBindingModel model)
        {
            return _assignmentService.AddAssignment(model.ToDto());
        }

        // PUT: api/Assignment/5
        [HttpPut]
        [Route("{id:int}")]
        public int Put(int id, AssignmentBindingModel model)
        {
            return _assignmentService.UpdateAssignment(id, model.ToDto());
        }

        // DELETE: api/Assignment/5
        [HttpDelete]
        [Route("{id:int}")]
        public int Delete(int id)
        {
            return _assignmentService.DeleteAssignment(id);
        }
    }
}
