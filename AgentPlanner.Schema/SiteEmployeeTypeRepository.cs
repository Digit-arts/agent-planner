using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class SiteEmployeeTypeRepository : BaseRepository<SiteEmployeeType, int>
    {
        public override int Add(SiteEmployeeType model)
        {
            Db.SiteEmployeeTypes.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override int Update(SiteEmployeeType model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(int id)
        {
            var siteEmployeeType = Get(id);
            Db.SiteEmployeeTypes.Remove(siteEmployeeType);
            return SaveChanges();
        }

        public int RemoveAllSiteEmployeeTypes(int siteId)
        {
            var siteEmployeeTypes = GetSiteEmployeeTypesForSite(siteId);
            if (siteEmployeeTypes != null)
            {
                Db.SiteEmployeeTypes.RemoveRange(siteEmployeeTypes);
            }
            return SaveChanges();
        }

        public override SiteEmployeeType Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }

        public int Add(SiteEmployeeType[] siteEmployeeTypes)
        {
            Db.SiteEmployeeTypes.AddRange(siteEmployeeTypes);
            return SaveChanges();
        }

        public SiteEmployeeType[] GetSiteEmployeeTypesForSite(int siteId)
        {
            return GetIQueryable().Where(x => x.SiteId == siteId).ToArray();
        }
        
        private IQueryable<SiteEmployeeType> GetIQueryable()
        {
            return Db.SiteEmployeeTypes;
        }
    }
}