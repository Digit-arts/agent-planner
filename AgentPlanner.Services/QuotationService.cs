using System.Linq;
using AgentPlanner.Entities.Billing;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class QuotationService
    {
        private readonly QuotationRepository _quotationRepository;
        private readonly ClientService _clientService;

        public QuotationService()
        {
            _quotationRepository = new QuotationRepository();
            _clientService = new ClientService();
        }

        public int Add(Quotation quotation)
        {
            return _quotationRepository.Add(quotation.ToDbo());
        }

        public int Remove(int id)
        {
            return _quotationRepository.Remove(id);
        }

        public int Update(int id, Quotation quotation)
        {
            quotation.Id = id;
            return _quotationRepository.Update(quotation.ToDbo());
        }

        public Quotation Get(int id)
        {
            var quotation =  _quotationRepository.Get(id).ToDto();
            quotation.Client = _clientService.GetClient(quotation.ClientId);
            quotation.Site = new SiteService().GetSite(quotation.SiteId);
            return quotation;
        }

        public Quotation[] GetAllBySite(int siteId)
        {
            var quotations = _quotationRepository.GetBySite(siteId).ToDto();
            var clients = _clientService.GetAll(quotations.Select(x => x.ClientId).Distinct().ToArray());
            foreach (var quotation in quotations)
            {
                quotation.Client = clients.FirstOrDefault(x => x.Id == quotation.ClientId);
            }
            return quotations;
        }

        public Quotation[] GetAllBySiteAndClient(int siteId, int clientId)
        {
            return _quotationRepository.GetBySiteAndClient(siteId, clientId).ToDto();
        }


    }
}
