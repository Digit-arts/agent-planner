using AgentPlanner.Entities.Contract;
using System;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.Entities.Employee
{
    public class Assignment
    {
        public int Id { get; set; }
        public AssignmentTypes AssignmentTypeId { get; set; }
        public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsDeleted { get; set; }

        public double? TotalRegularTimeHours { get; set; }
        public double? TotalHolidayHours { get; set; }
        public double? TotalWeekEndHours { get; set; }
        public double? TotalNightTimeHours { get; set; }

        public double? RegularHoursRate { get; set; }
        public double? HolidayHoursRate { get; set; }
        public double? WeekHoursRate { get; set; }
        public double? NightTimeHoursRate { get; set; }

        public AssignmentType AssignmentType { get; set; }
        public Contract.Contract Contract { get; set; }
        public Employee Employee { get; set; }
    }
}
