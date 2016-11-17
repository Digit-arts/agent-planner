using System;

namespace AgentPlanner.BindingModels.Employee
{
    public class EmployeeBindingModel
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? PhotoResouceId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
    }
}