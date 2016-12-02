using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class BillingRateConfigurationRepository  : BaseRepository<BillingRateConfiguration, int>
    {
        public override int Add(BillingRateConfiguration model)
        {
            throw new NotImplementedException();
        }

        public override int Update(BillingRateConfiguration model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public override BillingRateConfiguration Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }

        public BillingRateConfiguration Get()
        {
            return GetIQueryable().FirstOrDefault();
        }

        public BillingRateConfiguration[] GetAll()
        {
            return GetIQueryable().ToArray();
        }

        private IQueryable<BillingRateConfiguration> GetIQueryable()
        {
            return Db.BillingRateConfigurations.AsQueryable();
        }
    }
}