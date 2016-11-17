using System;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.Entities.User
{
    public class UserRole
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Roles RoleId { get; set; }
        public Role Role { get; set; }
    }
}
