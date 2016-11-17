using AgentPlanner.Entities.Enums;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;
using AssignmentType = AgentPlanner.Entities.Contract.AssignmentType;

namespace AgentPlanner.Services
{
    public class AssignmentTypeService
    {
        private readonly AssignmentTypeRepository _assignmentTypeRepository;

        public AssignmentTypeService()
        {
            _assignmentTypeRepository = new AssignmentTypeRepository();
        }

        public AssignmentType Get(AssignmentTypes type)
        {
            return _assignmentTypeRepository.Get((byte) type).ToDto();
        }

        public AssignmentType[] GetAllAssignmentTypes()
        {
            return _assignmentTypeRepository.GetAllAssignmentTypes().ToDto();
        }
    }
}
