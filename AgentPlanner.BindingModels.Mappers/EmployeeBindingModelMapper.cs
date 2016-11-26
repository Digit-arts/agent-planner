using System.Collections.Generic;
using System.Linq;
using AgentPlanner.BindingModels.Employee;
using AgentPlanner.Entities.Employee;

namespace AgentPlanner.BindingModels.Mappers
{
    public static class EmployeeBindingModelMapper
    {
        #region Employee binding model mapper

        public static Entities.Employee.Employee ToDto(this EmployeeBindingModel employee)
        {
            return new Entities.Employee.Employee
            {
                EmployeeCode = employee.EmployeeCode,
                EmployeeTypeId = employee.EmployeeTypeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                Address2 = employee.Address2,
                ZipCode = employee.ZipCode,
                City = employee.City,
                EmailAddress = employee.EmailAddress,
                PhoneNumber = employee.PhoneNumber,
                PhotoResouceId = employee.PhotoResouceId,
                DateOfBirth = employee.DateOfBirth,
                Comments = employee.Comments,
                IsActive = employee.IsActive
            };
        }

        #endregion

        #region SiteEmployeeType binding model mapper

        public static Entities.Employee.SiteEmployeeType ToDto(this SiteEmployeeTypeBindingModel model)
        {
            return new SiteEmployeeType
            {
                EmployeeTypeId = model.EmployeeTypeId
            };
        }

        public static Entities.Employee.SiteEmployeeType[] ToDtos(this IEnumerable<SiteEmployeeTypeBindingModel> models)
        {
            return models?.Select(x => x.ToDto()).ToArray();
        }

        #endregion
    }
}