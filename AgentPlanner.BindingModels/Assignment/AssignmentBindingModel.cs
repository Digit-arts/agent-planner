using System;

namespace AgentPlanner.BindingModels.Assignment
{
    public class AssignmentBindingModel
    {
        public byte AssignmentTypeId { get; set; }
        public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double? TotalRegularTimeHours { get; set; }
        public double? TotalHolidayHours { get; set; }
        public double? TotalWeekEndHours { get; set; }
        public double? TotalNightTimeHours { get; set; }
    }
}