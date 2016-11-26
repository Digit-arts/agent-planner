using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using AgentPlanner.BindingModels.Billing;
using AgentPlanner.BindingModels.Mappers;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Billing;
using AgentPlanner.ViewModels.Mappers;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/quotation")]
    public class QuotationController : BaseController
    {
        private readonly QuotationService _quotationService;

        public QuotationController()
        {
            _quotationService = new QuotationService();
        }

        [HttpPost]
        [Route("")]
        public int AddQuotation(QuotationBindingModel model)
        {
            return _quotationService.Add(model.ToDto());
        }

        [HttpGet]
        [Route("{id:int}")]
        public QuotationViewModel GetQuotation(int id)
        {
            return _quotationService.Get(id).ToVm();
        }

        [HttpGet]
        [Route("site/{siteId}")]
        public QuotationViewModel[] GetAllBySite(int siteId)
        {
            return _quotationService.GetAllBySite(siteId).ToVm();
        }

        [HttpGet]
        [Route("site/{siteId}/client/{clientId}")]
        public QuotationViewModel[] GetAllBySiteAndClient(int siteId, int clientId)
        {
            return _quotationService.GetAllBySiteAndClient(siteId, clientId).ToVm();
        }

        [HttpPut]
        [Route("{id:int}")]
        public int UpdateQuotation(int id, QuotationBindingModel model)
        {
            return _quotationService.Update(id, model.ToDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public int DeleteQuotation(int id)
        {
            return _quotationService.Remove(id);
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
            var quotation = _quotationService.Get(id).ToVm();
            var pdf = new PdfGenerationService().GeneratePdf(TemplatePath.Quotation, quotation, "quotation", typeof(QuotationViewModel), resources);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(pdf);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return response;
        }
    }
}
