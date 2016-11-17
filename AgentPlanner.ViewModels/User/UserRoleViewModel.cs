using System;

namespace AgentPlanner.ViewModels.User
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public byte RoleId { get; set; }
        public RoleViewModel Role { get; set; }
    }
}
