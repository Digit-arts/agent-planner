using System;

namespace AgentPlanner.Entities.Client
{
    public class Site
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string SideCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        
        public Client Client { get; set; }
    }
}
