using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Billing;
using AgentPlanner.ViewModels.Contract;
using AgentPlanner.ViewModels.Mappers;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/invoice")]
    public class InvoiceController : BaseController
    {
        private readonly ContractService _contractService;

        public InvoiceController()
        {
            _contractService = new ContractService();
        }

        [Route("site/{siteId:int}")]
        public ContractViewModel[] GetAllBySite(int siteId)
        {
            return _contractService.GetContractsAsInvoiceForSite(siteId).ToVm();
        }

        [HttpGet]
        [Route("export/{id:int}")]
        [AllowAnonymous]
        public HttpResponseMessage Export(int id)
        {
            var resources = new[]
            {
                HttpContext.Current.Server.MapPath("~/Content/bootstrap-paper.min.css")
            };
            var contract = _contractService.Get(id).ToVm();
            var pdf = new PdfGenerationService().GeneratePdf(TemplatePath.Invoice, contract, "invoice", typeof(ContractViewModel), resources);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(pdf);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return response;
        }
    }
}
