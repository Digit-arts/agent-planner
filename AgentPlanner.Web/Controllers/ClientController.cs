using System.Web.Http;
using AgentPlanner.BindingModels.Client;
using AgentPlanner.BindingModels.Mappers;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Client;
using AgentPlanner.ViewModels.Mappers;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : BaseController
    {
        private readonly ClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService();
        }

        // GET: api/client
        [HttpGet]
        [Route("list/{pageSize:int}/{pageNumber:int}")]
        public ClientListViewModel Get(int pageSize, int pageNumber)
        {
            return new ClientListViewModel
            {
                ClientViewModels = _clientService.GetPaginatedClients(pageSize, pageNumber).ToVms(),
                ClientCount = _clientService.GetTotalClientsCount()
            };
        }
        [HttpPost]
        [Route("search")]
        public ClientViewModel[] Search(string searchterm)
        {
            return _clientService.SearchClient(searchterm).ToVms();
        }
        // GET: api/client/5
        [HttpGet]
        [Route("{id:int}")]
        public ClientViewModel Get(int id)
        {
            return _clientService.GetClient(id).ToVm();
        }

        // POST: api/client
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(ClientBindingModel client)
        {
            return Ok(_clientService.AddClient(client.ToDto()));
        }

        // PUT: api/Client/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, ClientBindingModel client)
        {
            return Ok(_clientService.UpdateClient(id, client.ToDto()));
        }

        // DELETE: api/Client/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_clientService.DeleteClient(id));
        }

        [HttpGet]
        [Route("codecheck/{code}")]
        public bool CodeCheck(string code)
        {
            return _clientService.CheckCheckCode(code);
        }
    }
}
