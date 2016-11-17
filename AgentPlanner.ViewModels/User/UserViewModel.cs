using System;

namespace AgentPlanner.ViewModels.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserRoleViewModel[] UserRoles { get; set; }
    }
}
