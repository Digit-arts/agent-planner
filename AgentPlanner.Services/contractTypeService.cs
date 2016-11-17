using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;
using ContractType = AgentPlanner.Entities.Contract.ContractType;

namespace AgentPlanner.Services
{
    public class ContractTypeService
    {
        private readonly ContractTypeRepository _contractTypeRepository;

        public ContractTypeService()
        {
            _contractTypeRepository = new ContractTypeRepository();
        }

        public ContractType[] GetAllContractTypes()
        {
            return _contractTypeRepository.GetAllContractTypes().ToDto();
        }
    }
}
