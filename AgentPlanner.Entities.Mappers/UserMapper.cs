using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Enums;
using AgentPlanner.Entities.User;

namespace AgentPlanner.Entities.Mappers
{
    public static class UserMapper
    {
        #region User
        public static User.User ToDto(this DataAccess.User user)
        {
            if (user == null)
                return null;
            return new User.User
            {
                CreatedDate = user.CreatedDate,
                DeletedDate = user.DeletedDate,
                EmailAddress = user.EmailAddress,
                FullName = user.FullName,
                Id = user.Id,
                MobileNumber = user.MobileNumber,
                PasswordResetKey = user.PasswordResetKey,
                UserRoles = user.UserRoles.ToDto()
            };
        }

        public static User.User[] ToDto(this IEnumerable<DataAccess.User> users)
        {
            return users.Select(x => x.ToDto()).ToArray();
        }

        public static DataAccess.User ToDbo(this User.User user)
        {
            return new DataAccess.User
            {
                CreatedDate = user.CreatedDate,
                DeletedDate = user.DeletedDate,
                EmailAddress = user.EmailAddress,
                FullName = user.FullName,
                Id = user.Id,
                MobileNumber = user.MobileNumber,
                PasswordResetKey = user.PasswordResetKey,
                Password = user.Password
            };
        }
        #endregion

        #region Role

        public static Role ToDto(this DataAccess.Role role)
        {
            return new Role
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }
        #endregion

        #region UserRole

        public static UserRole ToDto(this DataAccess.UserRole userRole)
        {
            return new UserRole
            {
                Id = userRole.Id,
                RoleId = (Roles)userRole.RoleId,
                UserId = userRole.UserId,
                Role = userRole.Role.ToDto()
            };
        }

        public static UserRole[] ToDto(this IEnumerable<DataAccess.UserRole> userRoles)
        {
            return userRoles.Select(x => x.ToDto()).ToArray();
        }

        public static DataAccess.UserRole ToDbo(this UserRole userRole)
        {
            return new DataAccess.UserRole
            {
                Id = userRole.Id,
                RoleId = (byte) userRole.RoleId,
                UserId = userRole.UserId
            };
        }

        public static DataAccess.UserRole[] ToDbo(this IEnumerable<UserRole> userRoles)
        {
            return userRoles.Select(x => x.ToDbo()).ToArray();
        }
        #endregion
    }
}
