using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class QuotationRepository: BaseRepository<Quotation,int>
    {
        public override int Add(Quotation model)
        {
            model.DateAdded = DateTime.UtcNow;
            Db.Quotations.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override int Update(Quotation model)
        {
            var quotation = Get(model.Id);
            quotation.ContractTypeId = model.ContractTypeId;
            quotation.StartDate = model.StartDate;
            quotation.EndDate = model.EndDate;
            quotation.ClientId = model.ClientId;
            quotation.BillingRate = model.BillingRate;
            return SaveChanges();
        }

        public override int Remove(int id)
        {
            var model = Get(id);
            Db.Quotations.Remove(model);
            return SaveChanges();
        }

        public override Quotation Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }

        public Quotation[] GetBySite(int siteId)
        {
            return GetIQueryable().Where(x => x.SiteId == siteId).ToArray();
        }

        public Quotation[] GetBySiteAndClient(int siteId, int clientId)
        {
            return GetIQueryable().Where(x => x.SiteId == siteId && x.ClientId == clientId).ToArray();
        }

        private IQueryable<Quotation> GetIQueryable()
        {
            return Db.Quotations.AsQueryable();
        } 
    }
}
