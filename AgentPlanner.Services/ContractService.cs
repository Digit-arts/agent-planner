using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Contract;
using AgentPlanner.Entities.Enums;
using AgentPlanner.Entities.Exceptions;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class ContractService
    {
        private readonly ContractRepository _contractRepository;
      
        public ContractService()
        {
            _contractRepository = new ContractRepository();
        }

        public int AddContract(Contract contract)
        {
            return _contractRepository.Add(contract.ToDbo());
        }

        public int UpdateContract(int contractId, Contract contract)
        {
            contract.Id = contractId;
            return _contractRepository.Update(contract.ToDbo());
        }

        public Contract[] GetAll(int siteId)
        {
            return _contractRepository.GetAll(siteId).ToDto();
        }

        public Contract Get(int id)
        {
            return _contractRepository.Get(id).ToDto();
        }
        public Contract[] GetContracts(int id, int pageSize, int page = 1)
        {
            return _contractRepository.GetContracts(id, pageSize, (page - 1) * pageSize).ToDto();
        }
        public int GetTotalContractsCount(int siteId)
        {
            return _contractRepository.Count(siteId);
        }
        public int DeleteContract(int id)
        {
            var res =  _contractRepository.Remove(id);
            var assignmentService = new AssignmentService();
            var assignments = assignmentService.GetAssignmentsByContractId(id);
            foreach (var assignment in assignments)
            {
                assignmentService.DeleteAssignment(assignment.Id);
            }
            return res;
        }

        public Contract[] GetContractsForSites(int[] siteIds)
        {
            var siteContracts = new List<Contract>();

            foreach (var siteId in siteIds)
            {
                siteContracts.AddRange(_contractRepository.GetAll(siteId).ToDto());
            }
            return siteContracts.ToArray();
        }

        public Contract[] GetContractsAsInvoiceForSite(int siteId)
        {
            return _contractRepository.GetContractsAsInvoices(siteId).ToDto();
        }

        public int CreateInvoiceForContract(int contractId)
        {
            AssignmentService assignmentService = new AssignmentService();
            var contract = _contractRepository.Get(contractId);

            if(contract.InvoiceNumber.HasValue && contract.InvoiceNumber >= 1) throw new InvoiceAlreadyCreatedException();

            var assignments = assignmentService.GetAssignmentsByContractId(contractId);


            foreach (var assignment in assignments)
            {
                // we must alwasys calculate the hours even if SundayRateIncrease, NightTimeRateIncrease , PublicHolidayRateIncrease is false.
                // if false hours put in under these days will be regular hours.
                // if true you will increase the hourly rate percentage
                assignment.TotalWeekEndHours = assignmentService.CalculateWeekEndHours(assignment);
                if (contract.SundayRateIncrease)
                {
                    assignment.WeekHoursRate = assignmentService.AddPercentageIncreaseInRate(contract.BillingRate, RateIncrease.Weekend);
                }
                else
                {
                    assignment.WeekHoursRate = contract.BillingRate;
                }

                assignment.TotalNightTimeHours = assignmentService.CalculateNightTimeHours(assignment);
                if (contract.NightTimeRateIncrease)
                {
                    assignment.NightTimeHoursRate = assignmentService.AddPercentageIncreaseInRate(contract.BillingRate,
                        RateIncrease.Night);
                }
                else
                {
                    assignment.NightTimeHoursRate = contract.BillingRate;
                }

                assignment.TotalHolidayHours = assignmentService.CalculateHolidayHours(assignment);
                if (contract.PublicHolidayRateIncrease)
                {
                    assignment.HolidayHoursRate = assignmentService.AddPercentageIncreaseInRate(contract.BillingRate,
                        RateIncrease.Holiday);
                }
                else
                {
                    assignment.HolidayHoursRate = contract.BillingRate;
                }

                assignment.TotalRegularTimeHours = assignmentService.CalculateRegularTimeHours(assignment);
                assignment.RegularHoursRate = contract.BillingRate;

                assignmentService.UpdateAssignment(assignment.Id, assignment);
            }


            
            contract.InvoiceNumber = 1;
            return _contractRepository.Update(contract);
        }

        
    }
}
