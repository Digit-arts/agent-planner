using System;
using AgentPlanner.Entities.Resources;

namespace AgentPlanner.Entities.Employee
{
    public class Employee
    {
        public int Id { get; set; }
        public byte EmployeeTypeId { get; set; }
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
        public DateTime CreatedDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public Resource Photo { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
