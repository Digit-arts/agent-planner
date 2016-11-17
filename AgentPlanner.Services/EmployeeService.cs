using System;
using System.Collections.Generic;
using AgentPlanner.Repositories;
using AgentPlanner.Entities.Employee;
using AgentPlanner.Entities.Exceptions;
using AgentPlanner.Entities.Mappers;

namespace AgentPlanner.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public Employee GetEmployee(int employeeId)
        {
            return _employeeRepository.Get(employeeId).ToDto();
        }


        public int AddEmployee(Employee employee)
        {
            var employeeCode = employee.EmployeeCode.ToUpper();

            if(_employeeRepository.IsCodeExisting(employeeCode)) throw new EmployeeCodeDuplicateException();

            employee.EmployeeCode = employeeCode;

            return _employeeRepository.Add(employee.ToDbo());
        }

        public int UpdateEmployee(int employeeId, Employee employee)
        {
            employee.Id = employeeId;

            var newEmployeeCode = employee.EmployeeCode.ToUpper();

            var dbEmployee = _employeeRepository.Get(employeeId);

            if (!dbEmployee.EmployeeCode.Equals(newEmployeeCode))
            {
                if (_employeeRepository.IsCodeExisting(newEmployeeCode)) throw new EmployeeCodeDuplicateException();

                employee.EmployeeCode = newEmployeeCode;
            }

            return _employeeRepository.Update(employee.ToDbo());
        }


        public int DeleteEmployee(int employeeId)
        {
            return _employeeRepository.Remove(employeeId);
        }


        public IEnumerable<Employee> GetPaginatedEmployees(int pageSize, int page = 1)
        {
            var resultsToSkip = (page - 1) * pageSize;

            return _employeeRepository.GetEmployees(pageSize, resultsToSkip).ToDtos();
        }

        public IEnumerable<Employee> SearchEmployees(string searchTerm)
        {
            return _employeeRepository.SearchTerm(searchTerm).ToDtos();
        } 

        public int GetTotalEmployeesCount()
        {
            return _employeeRepository.Count();
        }

        public bool CheckEmployeeCode(string code)
        {
            return _employeeRepository.IsCodeExisting(code?.ToUpper());
        }
    }
}