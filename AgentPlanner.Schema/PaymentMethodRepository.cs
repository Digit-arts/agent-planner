using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethod, int>
    {
        public override int Add(PaymentMethod model)
        {
            throw new NotImplementedException();
        }

        public override int Update(PaymentMethod model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public PaymentMethod[] GetAll()
        {
            return GetIQueryable().ToArray();
        }
        public override PaymentMethod Get(int id)
        {
           return  GetIQueryable().FirstOrDefault(x => x.Id == id);
        }
        private IQueryable<PaymentMethod> GetIQueryable()
        {
            return Db.PaymentMethods.OrderByDescending(x => x.MethodName);
        }
    }
}
