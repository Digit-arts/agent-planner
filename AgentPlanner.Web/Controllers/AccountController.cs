using System;
using System.Web.Http;
using AgentPlanner.Entities.Enums;
using AgentPlanner.Entities.User;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Mappers;
using AgentPlanner.ViewModels.User;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        private readonly UserService _userService;

        public AccountController()
        {
            _userService = new UserService();
        }

        [Route("info")]
        [HttpGet]
        public UserViewModel AccountInfo()
        {
            return _userService.Get(LoggedInUserId).ToVm();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("test")]
        public Guid CreateTestAccount()
        {
            return _userService.AddUser(new User
            {
                EmailAddress = "asad.aries90@gmail.com",
                FullName = "Muhammad Asad",
                MobileNumber = "0300 5534505",
                Password = "123",
                UserRoles = new[]
                {
                    new UserRole
                    {
                        RoleId = Roles.ADMIN
                    }
                }
            });
        }
    }
}
