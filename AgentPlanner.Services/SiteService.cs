using System;
using System.Collections.Generic;
using AgentPlanner.Entities.Client;
using AgentPlanner.Entities.Exceptions;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class SiteService
    {
        private readonly SiteRepository _siteRepository;

        public SiteService()
        {
            _siteRepository = new SiteRepository();
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

            return _siteRepository.Add(site.ToDbo());
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


            return _siteRepository.Update(site.ToDbo());
        }

        public int DeleteSite(int siteId)
        {
            return _siteRepository.Remove(siteId);
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