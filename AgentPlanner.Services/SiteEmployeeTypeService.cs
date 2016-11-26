using AgentPlanner.Entities.Employee;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class SiteEmployeeTypeService
    {
        private readonly SiteEmployeeTypeRepository _siteEmployeeTypeRepository;

        public SiteEmployeeTypeService()
        {
            _siteEmployeeTypeRepository = new SiteEmployeeTypeRepository();
        }

        public int AddSiteEmployeeType(SiteEmployeeType siteEmployeeType)
        {
            return _siteEmployeeTypeRepository.Add(siteEmployeeType.ToDbo());
        }

        public SiteEmployeeType[] GetSiteEmployeeTypesForSite(int siteId)
        {
            return _siteEmployeeTypeRepository.GetSiteEmployeeTypesForSite(siteId).ToDtos();
        }

        public int DeleteSiteEmployeeType(int siteEmployeeTypeId)
        {
            return _siteEmployeeTypeRepository.Remove(siteEmployeeTypeId);
        }

        public int AddSiteEmployeeTypes(int siteId, SiteEmployeeType[] siteEmployeeTypes)
        {
            if (siteEmployeeTypes == null) return 0;

            foreach (var siteEmployeeType in siteEmployeeTypes)
            {
                siteEmployeeType.SiteId = siteId;
            }

            return _siteEmployeeTypeRepository.Add(siteEmployeeTypes.ToDbos());
        }

        public int RemoveAllSiteEmployeeTypes(int siteId)
        {
            return _siteEmployeeTypeRepository.RemoveAllSiteEmployeeTypes(siteId);
        }
    }
}