using System.Collections.Generic;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Entities;

namespace AgentPlanner.Entities.Mappers
{
    public static class EmployeeMapper
    {
        #region Employee mappers

        public static Employee.Employee ToDto(this DataAccess.Employee employee)
        {
            if (employee == null) return null;

            return new Employee.Employee
            {
                Id = employee.Id,
                EmployeeTypeId = employee.EmployeeTypeId,
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
                Photo = employee.Resource?.ToDto(),
                EmployeeType = employee.EmployeeType.ToDto()
            };
        }

        public static Employee.Employee[] ToDtos(this IEnumerable<DataAccess.Employee> employees)
        {
            return employees.Select(x => x.ToDto()).ToArray();
        }

        public static DataAccess.Employee ToDbo(this Employee.Employee employee)
        {
            return new DataAccess.Employee
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
                ModificationDate = employee.ModificationDate
            };
        }

        #endregion

        #region EmployeeType mappers

        public static Employee.EmployeeType ToDto(this DataAccess.EmployeeType employeeType)
        {
            if (employeeType == null) return null;

            return new Employee.EmployeeType
            {
                Id = employeeType.Id,
                Name = employeeType.Name
            };
        }

        public static Employee.EmployeeType[] ToDtos(this IEnumerable<DataAccess.EmployeeType> employeeTypes)
        {
            return employeeTypes.Select(x => x.ToDto()).ToArray();
        }

        #endregion

        #region SiteEmployeeType mappers

        public static Employee.SiteEmployeeType ToDto(this SiteEmployeeType siteEmployeeType)
        {
            if (siteEmployeeType == null) return null;

            return new Employee.SiteEmployeeType
            {
                Id = siteEmployeeType.Id,
                SiteId = siteEmployeeType.SiteId,
                EmployeeTypeId = siteEmployeeType.EmployeeTypeId,
                Site = siteEmployeeType.Site.ToDto(),
                EmployeeType = siteEmployeeType.EmployeeType.ToDto()
            };
        }

        public static Employee.SiteEmployeeType[] ToDtos(this IEnumerable<SiteEmployeeType> siteEmployeeTypes)
        {
            return siteEmployeeTypes.Select(x => x.ToDto()).ToArray();
        }

        public static SiteEmployeeType ToDbo(this Employee.SiteEmployeeType siteEmployeeType)
        {
            return new SiteEmployeeType
            {
                Id = siteEmployeeType.Id,
                SiteId = siteEmployeeType.SiteId,
                EmployeeTypeId = siteEmployeeType.EmployeeTypeId
            };
        }

        public static SiteEmployeeType[] ToDbos(this IEnumerable<Employee.SiteEmployeeType> siteEmployeeTypes)
        {
            return siteEmployeeTypes.Select(x => x.ToDbo()).ToArray();
        }

        #endregion
    }
}