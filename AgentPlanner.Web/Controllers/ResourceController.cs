using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AgentPlanner.BindingModels.Mappers;
using AgentPlanner.BindingModels.Resources;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Mappers;
using AgentPlanner.ViewModels.Resource;
using AgentPlanner.Web.Models;
using Newtonsoft.Json;

namespace AgentPlanner.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/resource")]
    public class ResourceController : BaseController
    {
        private readonly ResourceService _resourceService;

        public ResourceController()
        {
            _resourceService = new ResourceService();
        }

        [HttpPost]
        [Route("")]
        public async Task<ResourceViewModel> UploadResource()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartFormDataStreamProvider(Utility.UploadFullPath);
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            var tempFilePath = result.FileData.First().LocalFileName;
            var resourceFullPath = "";
            var resourceDirectory = "";
            try
            {
                var resource = GetDeserializedFileName(result.FileData.First());
                resourceDirectory = $"{Utility.UploadRelativePath}{Guid.NewGuid()}";
                Utility.CreateDirectory(resourceDirectory);

                var resourcePath = $"{resourceDirectory}/{resource.ResourceName}";
                resource.ResourcePath = resourcePath;
                resourceFullPath = HttpContext.Current.Server.MapPath(resourcePath);
                File.Move(tempFilePath, resourceFullPath);
                File.Delete(tempFilePath);

                var r = _resourceService.AddResource(resource.ToDto());

                return r.ToVm(Utility.SiteUrl);
            }
            catch (Exception)
            {
                Utility.DeleteFile(tempFilePath);
                Utility.DeleteFile(resourceFullPath);
                Utility.DeleteDirectory(resourceDirectory);
                throw;
            }

        }

        [HttpGet]
        [Route("{resourceId}/{fileName}")]
        public HttpResponseMessage GetResource(int resourceId, string fileName)
        {
            var resource = _resourceService.Get(resourceId);
            if (!fileName.Equals(resource.ResourceName))
            {
                throw new FileNotFoundException();
            }
            var filePath = HttpContext.Current.Server.MapPath(resource.ResourcePath);
            if (!File.Exists(filePath))
            {
                throw new Exception("File not found on server. Reference id: " + resource.Id);
            }
            var memoryStream =
                new MemoryStream(File.ReadAllBytes(filePath));
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(memoryStream.ToArray());
            memoryStream.Close();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(resource.ResourceType);
            return response;
        }

        #region Private Methods
        private ResourceBindingModel GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            var extenstion = Path.GetExtension(fileName);
            return new ResourceBindingModel
            {
                ResourceType = fileData.Headers.ContentType.ToString(),
                ResourceExtenstion = extenstion,
                ResourceName = fileName
            };
        }

        private string GetFileName(MultipartFileData fileData)
        {
            return JsonConvert.DeserializeObject(fileData.Headers.ContentDisposition.FileName).ToString();
        }
        #endregion
    }
}
