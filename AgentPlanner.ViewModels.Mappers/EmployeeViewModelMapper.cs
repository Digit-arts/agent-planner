using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Employee;
using AgentPlanner.ViewModels.Employee;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class EmployeeViewModelMapper
    {
        #region Employee View Model mappers

        public static EmployeeViewModel ToVm(this Entities.Employee.Employee employee, string siteUrl)
        {
            if (employee == null) return null;

            return new EmployeeViewModel
            {
                Id = employee.Id,
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
                IsActive = employee.IsActive,
                CreatedDate = employee.CreatedDate,
                ModificationDate = employee.ModificationDate,
                Photo = employee.Photo?.ToVm(siteUrl),
                EmployeeTypeViewModel = employee.EmployeeType.ToVm()
            };
        }


        public static EmployeeViewModel ToVm(this Entities.Employee.Employee employee)
        {
            if (employee == null) return null;

            return new EmployeeViewModel
            {
                Id = employee.Id,
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
                IsActive = employee.IsActive,
                CreatedDate = employee.CreatedDate,
                ModificationDate = employee.ModificationDate,
                EmployeeTypeViewModel = employee.EmployeeType.ToVm()
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

        #endregion

        #region EmployeeType mappers

        public static EmployeeTypeViewModel ToVm(this Entities.Employee.EmployeeType employeeType)
        {
            return new EmployeeTypeViewModel
            {
                Id =  employeeType.Id,
                Name = employeeType.Name
            };
        }

        public static EmployeeTypeViewModel[] ToVms(this IEnumerable<Entities.Employee.EmployeeType> employeeTypes)
        {
            return employeeTypes.Select(x => x.ToVm()).ToArray();
        }

        #endregion

        #region SiteEmployeeType View Model mappers

        public static SiteEmployeeTypeViewModel ToVm(this SiteEmployeeType siteEmployeeType)
        {
            return new SiteEmployeeTypeViewModel
            {
                Id = siteEmployeeType.Id,
                SiteId = siteEmployeeType.SiteId,
                EmployeeTypeId = siteEmployeeType.EmployeeTypeId,
                SiteViewModel = siteEmployeeType.Site.ToVm(),
                EmployeeTypeViewModel = siteEmployeeType.EmployeeType.ToVm()
            };
        }

        public static SiteEmployeeTypeViewModel[] ToVms(this IEnumerable<SiteEmployeeType> siteEmployeeTypes)
        {
            return siteEmployeeTypes.Select(x => x.ToVm()).ToArray();
        }

        #endregion
    }
}