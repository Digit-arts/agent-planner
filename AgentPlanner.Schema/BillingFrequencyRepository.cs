using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class BillingFrequencyRepository : BaseRepository<BillingFrequency, int>
    {
        public override int Add(BillingFrequency model)
        {
            throw new NotImplementedException();
        }

        public override int Update(BillingFrequency model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public override BillingFrequency Get(int id)
        {
            throw new NotImplementedException();
        }
        public BillingFrequency[] GetAllBillingFrequenciess()
        {
            return GetIQueryable().ToArray();
        }
        private IQueryable<DataAccess.BillingFrequency> GetIQueryable()
        {
            return Db.BillingFrequencies;
        }
    }
}
