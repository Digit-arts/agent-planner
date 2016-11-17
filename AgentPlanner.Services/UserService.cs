using System;
using System.Transactions;
using AgentPlanner.Common.HashingHelper;
using AgentPlanner.Entities.Exceptions;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Entities.User;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User Get(Guid userId)
        {
            return _userRepository.Get(userId).ToDto();
        }

        public User Validate(string email, string password)
        {
            var user = _userRepository.Get(email);
            if (user == null)
            {
                throw new InvalidEmailOrPasswordException();
            }
            var isEqual = HashingHelper.Verify(password, user.Password);
            if (!isEqual)
            {
                throw new InvalidEmailOrPasswordException();
            }
            return user.ToDto();
        }

        public Guid AddUser(User user)
        {
            var exists = _userRepository.Exists(user.EmailAddress);
            if (exists == true)
            {
                throw new UserWithSameEmailException();
            }
            user.Id = Guid.NewGuid();
            user.Password = HashingHelper.Hash(user.Password);
            if (user.UserRoles == null || user.UserRoles.Length == 0)
            {
                throw new UserRoleNotProvidedException();
            }
            using (var scope = new TransactionScope())
            {
                _userRepository.Add(user.ToDbo());
                _userRepository.AddUserRole(user.Id, user.UserRoles.ToDbo());
                scope.Complete();
            }
            return user.Id;
        }
    }
}
