using AgentPlanner.Entities.Employee;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class EmployeeTypeService
    {
        private readonly EmployeeTypeRepository _employeeTypeRepository;

        public EmployeeTypeService()
        {
            _employeeTypeRepository = new EmployeeTypeRepository();
        }

        public EmployeeType[] GetAllEmployeeTypes()
        {
            return _employeeTypeRepository.GetAllEmployeeTypes().ToDtos();
        }
    }
}