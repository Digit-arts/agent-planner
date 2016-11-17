using System.Collections.Generic;
using System.Linq;
using AgentPlanner.ViewModels.Assignment;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class AssignmentViewModelMapper
    {
        public static AssignmentViewModel ToVm(this Entities.Employee.Assignment assignment)
        {
            if (assignment == null) return null;

            return new AssignmentViewModel
            {
                Id = assignment.Id,
                AssignmentTypeId = (byte)assignment.AssignmentTypeId,
                ContractId = assignment.ContractId,
                EmployeeId = assignment.EmployeeId,
                StartDateTime = assignment.StartDateTime,
                EndDateTime = assignment.EndDateTime,
                Employee = assignment.Employee.ToVm(),
                AssignmentType = assignment.AssignmentType.ToVm(),
                Contract =assignment.Contract.ToVm()
            };
        }

        public static AssignmentViewModel[] ToVms(this IEnumerable<Entities.Employee.Assignment> assignments)
        {
            return assignments.Select(x => x.ToVm()).ToArray();
        }
    }
}