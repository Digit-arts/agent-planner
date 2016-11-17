using System;
using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Employee;
using AgentPlanner.Entities.Exceptions;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class AssignmentService
    {
        private readonly AssignmentRepository _assignmentRepository;
        private readonly EmployeeService _employeeService;
        private readonly ContractService _contractService;
        private readonly AssignmentTypeService _assignmentTypeService;
        private readonly SiteService _siteService;

        public AssignmentService()
        {
            _assignmentRepository = new AssignmentRepository();
            _employeeService = new EmployeeService();
            _contractService= new ContractService();
            _assignmentTypeService = new AssignmentTypeService();
            _siteService = new SiteService();
        }

        public Assignment GetAssignment(int assignmentId)
        {
            return _assignmentRepository.Get(assignmentId).ToDto();
        }

        public int AddAssignment(Assignment assignment)
        {
            var contract = _contractService.Get(assignment.ContractId);

            if(assignment.StartDateTime < contract.StartDate || assignment.EndDateTime > contract.EndDate)
                throw new ContractAssignmentDateException();

            return _assignmentRepository.Add(assignment.ToDbo());
        }

        public int UpdateAssignment(int assignmentId, Assignment assignment)
        {
            assignment.Id = assignmentId;
            return _assignmentRepository.Update(assignment.ToDbo());
        }

        public int DeleteAssignment(int assignmentId)
        {
            return _assignmentRepository.Remove(assignmentId);
        }

        public Assignment[] GetPaginatedAssignments(int pageSize, int page = 1)
        {
            var resultsToSkip = (page - 1) * pageSize;

            return _assignmentRepository.GetAssignments(pageSize, resultsToSkip).ToDtos();
        }
        public Assignment[] GetByContractId(int contractId,int pageSize, int page = 1)
        {
            var resultsToSkip = (page - 1) * pageSize;

            var assignment=_assignmentRepository.GetByContractId(contractId,pageSize, resultsToSkip).ToDtos();
            foreach (var a in assignment)
            {
                a.Employee = _employeeService.GetEmployee(a.EmployeeId);
                a.Contract = _contractService.Get(a.ContractId);
                a.AssignmentType = _assignmentTypeService.Get(a.AssignmentTypeId);
            }
            return assignment;
        }
        public int GetTotalAssignmentsCount()
        {
            return _assignmentRepository.Count();
        }

        public int GetTotalAssignmentsCount(int contractId)
        {
            return _assignmentRepository.Count(contractId);
        }


        public Assignment[] GetAssignmentsByDates(DateTime startDate, DateTime endDate)
        {
            return _assignmentRepository.GetAssignmentsByDate(startDate, endDate).ToDtos();
        }

        public Assignment[] GetAssignmentsByEmployeeId(int employeeId, DateTime startDate, DateTime endDate)
        {
            return _assignmentRepository.GetAssignmentsByEmployeeId(employeeId, startDate.Date,endDate.Date).ToDtos();
        }

        public Assignment[] GetAssignmentsByContractId(int contractId, DateTime startDate, DateTime endDate)
        {
            return _assignmentRepository.GetAssignmentsByContractId(contractId, startDate.Date, endDate.Date).ToDtos();
        }

        public Assignment[] GetAssignmentsByClientId(int clientId, DateTime startDate, DateTime endDate)
        {
            var clientSiteIds = _siteService.GetSitesByClient(clientId).Select(x => x.Id).ToArray();
            var clientSitesContrats = _contractService.GetContractsForSites(clientSiteIds);

            var clientAssignments = new List<Assignment>();

            foreach (var contrat in clientSitesContrats)
            {
                clientAssignments.AddRange(_assignmentRepository.GetAssignmentsByContractId(contrat.Id, startDate, endDate).ToDtos());
            }
            return clientAssignments.ToArray();
        }
    }
}