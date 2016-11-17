using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class ContractTypeRepository : BaseRepository<ContractType, int>
    {
        public override int Add(ContractType model)
        {
            throw new NotImplementedException();
        }

        public override int Update(ContractType model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public override ContractType Get(int id)
        {
            throw new NotImplementedException();
        }
        public ContractType[] GetAllContractTypes()
        {
            return GetIQueryable().ToArray();
        }
        private IQueryable<ContractType> GetIQueryable()
        {
            return Db.ContractTypes;
        }
    }
}
