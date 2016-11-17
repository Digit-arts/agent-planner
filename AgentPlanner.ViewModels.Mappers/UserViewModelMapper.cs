using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.User;
using AgentPlanner.ViewModels.User;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class UserViewModelMapper
    {
        public static UserViewModel ToVm(this Entities.User.User user)
        {
            if (user == null) return null;
            return new UserViewModel
            {
                UserRoles = user.UserRoles.ToVm(),
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                CreatedDate = user.CreatedDate,
                FullName = user.FullName,
                MobileNumber = user.MobileNumber
            };
        }

        public static RoleViewModel ToVm(this Role role)
        {
            return new RoleViewModel
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }

        public static UserRoleViewModel ToVm(this UserRole userRole)
        {
            if (userRole == null) return null;
            return new UserRoleViewModel
            {
                Id = userRole.Id,
                Role = userRole.Role.ToVm(),
                RoleId = (byte) userRole.RoleId,
                UserId = userRole.UserId
            };
        }

        public static UserRoleViewModel[] ToVm(this IEnumerable<UserRole> userRoles)
        {
            return userRoles.Select(x => x.ToVm()).ToArray();
        }
    }
}
