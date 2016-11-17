using System.Collections.Generic;
using AgentPlanner.Entities.Contract;
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
            return _contractRepository.Remove(id);
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
    }
}
