using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class ContractRepository:BaseRepository<Contract,int>
    {
        public override int Add(Contract model)
        {
            model.CreatedDate = DateTime.UtcNow;
            Db.Contracts.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override int Update(Contract model)
        {
            var contract = Get(model.Id);
            contract.ModifiedDate = DateTime.UtcNow;

            contract.StartDate = model.StartDate;
            contract.EndDate = model.EndDate;
            contract.ContractTypeId = model.ContractTypeId;
            contract.BillingRate = model.BillingRate;
            contract.BillingFrequencyId = model.BillingFrequencyId;
            contract.Comments = model.Comments;
            contract.IsActive = model.IsActive;
            contract.NightTimeRateIncrease = model.NightTimeRateIncrease;
            contract.SundayRateIncrease = model.SundayRateIncrease;
            contract.PublicHolidayRateIncrease = model.PublicHolidayRateIncrease;
            contract.AssignmentTypeId = model.AssignmentTypeId;
            contract.InvoiceNumber = model.InvoiceNumber;
            return SaveChanges();
        }

        public override int Remove(int id)
        {
            var contract = Get(id);
            contract.IsDeleted = true;
            contract.DeletedDate = DateTime.UtcNow;
            return SaveChanges();
        }

        public override Contract Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }

        public Contract[] GetAll(int siteId)
        {
            return GetIQueryable().Where(x => x.SiteId == siteId).ToArray();
        }
        public int Count(int siteId)
        {
            return GetIQueryable().Count(x => x.SiteId== siteId);
        }
        public Contract[] GetContracts(int id,int pageSize, int skipSize)
        {
            return GetIQueryable().Where(x=>x.SiteId==id)
                .AsNoTracking()
                .Skip(() => skipSize)
                .Take(() => pageSize)
                .ToArray();
        }

        public Contract[] GetContractsAsInvoices(int siteId)
        {
            return GetIQueryable().Where(x => x.SiteId == siteId && x.InvoiceNumber.HasValue)
                .AsNoTracking()
                .ToArray();
        }

        private IQueryable<Contract> GetIQueryable()
        {
            return Db.Contracts.Where(x=> !x.IsDeleted).OrderByDescending(x => x.Id); ;
        } 
    }
}
