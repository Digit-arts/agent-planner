using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>
    {
        public override Guid Add(User model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.IsDeleted = false;
            Db.Users.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override Guid Update(User model)
        {
            throw new NotImplementedException();
        }

        public int AddUserRole(Guid userId, UserRole[] roles)
        {
            foreach (var userRole in roles)
            {
                userRole.UserId = userId;
            }
            Db.UserRoles.AddRange(roles);
            return SaveChanges();
        }

        public override int Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public override User Get(Guid id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id.Equals(id));
        }

        public bool Exists(string email)
        {
            return GetIQueryable().Any(x => x.EmailAddress.Equals(email));
        }

        public User Get(string emailAddress)
        {
            return GetIQueryable().FirstOrDefault(x => x.EmailAddress.Equals(emailAddress));
        }

        private IQueryable<User> GetIQueryable()
        {
            return from user in Db.Users
                   where user.IsDeleted == false
                   orderby user.FullName descending
                   select user;
        }
    }
}
