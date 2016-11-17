using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities;

namespace AgentPlanner.Entities.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee.Employee ToDto(this DataAccess.Employee employee)
        {
            if (employee == null) return null;

            return new Employee.Employee
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
                Photo = employee.Resource?.ToDto()
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
    }
}