using System.Collections.Generic;
using System.Linq;
using AgentPlanner.ViewModels.Employee;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class EmployeeViewModelMapper
    {
        public static EmployeeViewModel ToVm(this Entities.Employee.Employee employee, string siteUrl)
        {
            if (employee == null) return null;

            return new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
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
                IsActive = employee.IsActive,
                CreatedDate = employee.CreatedDate,
                ModificationDate = employee.ModificationDate,
                Photo = employee.Photo?.ToVm(siteUrl)
            };
        }


        public static EmployeeViewModel ToVm(this Entities.Employee.Employee employee)
        {
            if (employee == null) return null;

            return new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
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
                IsActive = employee.IsActive,
                CreatedDate = employee.CreatedDate,
                ModificationDate = employee.ModificationDate
            };
        }



        public static EmployeeViewModel[] ToVms(this IEnumerable<Entities.Employee.Employee> employees, string siteUrl)
        {
            return employees.Select(x => x.ToVm(siteUrl)).ToArray();
        }

        public static EmployeeViewModel[] ToVms(this IEnumerable<Entities.Employee.Employee> employees)
        {
            return employees.Select(x => x.ToVm()).ToArray();
        }
        
    }
}