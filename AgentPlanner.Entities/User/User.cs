using System;

namespace AgentPlanner.Entities.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string PasswordResetKey { get; set; }

        public UserRole[] UserRoles { get; set; }
    }
}
