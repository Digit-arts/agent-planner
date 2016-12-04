using System;

namespace AgentPlanner.ViewModels.Assignment
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public byte AssignmentTypeId { get; set; }
        public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double? TotalRegularTimeHours { get; set; }
        public double? TotalHolidayHours { get; set; }
        public double? TotalWeekEndHours { get; set; }
        public double? TotalNightTimeHours { get; set; }
        public double? RegularHoursRate { get; set; }
        public double? HolidayHoursRate { get; set; }
        public double? WeekHoursRate { get; set; }
        public double? NightTimeHoursRate { get; set; }

        public Contract.AssignmentTypeViewModel AssignmentType { get; set; }
        public Contract.ContractViewModel Contract { get; set; }
        public Employee.EmployeeViewModel Employee { get; set; }



        //public double TotalHours => TotalRegularTimeHours ?? 0;
        //public double TotalAmount => TotalHours*RegularHoursRate ?? 0;

        public double TotalAmount
        {
            get
            {
                var totalRegularAmount = (TotalRegularTimeHours ?? 0)*(RegularHoursRate ?? 0);
                var totalNightAmount = (TotalNightTimeHours ?? 0)*(NightTimeHoursRate ?? 0);
                var totalWeekendAmount = (TotalWeekEndHours ?? 0)*(WeekHoursRate ?? 0);
                var totalHolidayAmount = (TotalHolidayHours ?? 0)*(HolidayHoursRate ?? 0);
                return totalWeekendAmount + totalRegularAmount + totalNightAmount + totalHolidayAmount;
            }
        }
    }
}