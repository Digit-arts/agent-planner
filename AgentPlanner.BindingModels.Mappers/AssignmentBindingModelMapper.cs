using AgentPlanner.BindingModels.Assignment;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.BindingModels.Mappers
{
    public static class AssignmentBindingModelMapper
    {
        public static Entities.Employee.Assignment ToDto(this AssignmentBindingModel assignment)
        {
            return new Entities.Employee.Assignment
            {
                AssignmentTypeId = (AssignmentTypes)assignment.AssignmentTypeId,
                ContractId = assignment.ContractId,
                EmployeeId = assignment.EmployeeId,
                StartDateTime = assignment.StartDateTime,
                EndDateTime = assignment.EndDateTime,
                TotalHolidayHours = assignment.TotalHolidayHours,
                TotalNightTimeHours = assignment.TotalNightTimeHours,
                TotalRegularTimeHours = assignment.TotalRegularTimeHours,
                TotalWeekEndHours = assignment.TotalWeekEndHours
            };
        }
    }
}