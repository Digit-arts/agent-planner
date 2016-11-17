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

        public Contract.AssignmentTypeViewModel AssignmentType { get; set; }
        public Contract.ContractViewModel Contract { get; set; }
        public Employee.EmployeeViewModel Employee { get; set; }
    }
}