using AgentPlanner.BindingModels.Employee;

namespace AgentPlanner.BindingModels.Mappers
{
    public static class EmployeeBindingModelMapper
    {
        public static Entities.Employee.Employee ToDto(this EmployeeBindingModel employee)
        {
            return new Entities.Employee.Employee
            {
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
                IsActive = employee.IsActive
            };
        }
    }
}