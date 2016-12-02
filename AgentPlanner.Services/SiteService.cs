using System;
using System.Collections.Generic;
using System.Transactions;
using AgentPlanner.Entities.Client;
using AgentPlanner.Entities.Exceptions;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class SiteService
    {
        private readonly SiteRepository _siteRepository;
        private readonly SiteEmployeeTypeService _siteEmployeeTypeService;

        public SiteService()
        {
            _siteRepository = new SiteRepository();
            _siteEmployeeTypeService = new SiteEmployeeTypeService();

        }

        public Site GetSite(int siteId)
        {
            return _siteRepository.Get(siteId).ToDto();
        }

        public int AddSite(Site site)
        {
            var siteCode = site.SideCode.ToUpper();

            if(_siteRepository.IsCodeExisting(siteCode)) throw new SiteCodeDuplicateException();

            site.SideCode = siteCode;

            using (var scope = new TransactionScope())
            {
                var id = _siteRepository.Add(site.ToDbo());

                _siteEmployeeTypeService.AddSiteEmployeeTypes(id, site.SiteEmployeeTypes);
                scope.Complete();
                return id;
            }
        }

        public int UpdateSite(int siteId, Site site)
        {
            site.Id = siteId;

            var newSiteCode = site.SideCode.ToUpper();

            var dbSite = _siteRepository.Get(siteId);

            if (!dbSite.SideCode.Equals(newSiteCode))
            {
                if (_siteRepository.IsCodeExisting(newSiteCode))
                {
                    throw new SiteCodeDuplicateException();
                }
                site.SideCode = newSiteCode;
            }


            using (var scope = new TransactionScope())
            {
                var res = _siteRepository.Update(site.ToDbo());
                _siteEmployeeTypeService.RemoveAllSiteEmployeeTypes(siteId);
                _siteEmployeeTypeService.AddSiteEmployeeTypes(siteId, site.SiteEmployeeTypes);
                scope.Complete();
                return res;
            }
        }

        public int DeleteSite(int siteId)
        {
            var res =  _siteRepository.Remove(siteId);
            var contractService = new ContractService();
            var contracts = contractService.GetAll(siteId);
            foreach (var contract in contracts)
            {
                contractService.DeleteContract(contract.Id);
            }
            return res;
        }

        public int GetTotalSiteCount()
        {
            return _siteRepository.Count();
        }

        public IEnumerable<Site> GetPaginatedSites(int pageSize, int page = 1)
        {
            var resultsToSkip = (page - 1) * pageSize;

            return _siteRepository.GetSites(pageSize, resultsToSkip).ToDtos();
        }

        public IEnumerable<Site> GetSitesByClient(int clientId)
        {
            return _siteRepository.GetSites(clientId).ToDtos();
        }

        public bool CheckSiteCode(string code)
        {
            return _siteRepository.IsCodeExisting(code?.ToUpper());
        }
    }
}