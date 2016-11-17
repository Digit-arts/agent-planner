using System.Linq;
using System.Web.Http;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Mappers;
using AgentPlanner.ViewModels.Contract;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/assignmentType")]
    public class AssignmentTypeController : BaseController
    {
        private readonly AssignmentTypeService _assignmentTypeService;

        public AssignmentTypeController()
        {
            _assignmentTypeService = new AssignmentTypeService();
        }

        [Route("all")]
        [HttpGet]
        public AssignmentTypeViewModel[] GetAllAssignmentTypes()
        {
            return _assignmentTypeService.GetAllAssignmentTypes().ToVm().ToArray();
        }
    }
}
