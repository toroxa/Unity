using LLV.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LLV.Controllers.Api
{
    [RoutePrefix("api/os")]
    public class ApiOrdemServicoController : ApiController
    {
        [HttpGet]
        [Route("listar")]
        public ResultModel<IEnumerable<OrdemServicoModel>> GetOSs()
        {
            var result = new Result<IEnumerable<OrdemServicoModel>>();
            var oss = new[]
            {
                new OrdemServicoModel() { Id = 0, Codigo = "1" },
            };

            if (null == oss)
                return result.Empty();

            var osModels = oss.OrderBy(osModel => osModel.Id);

            result.SetResult(osModels);

            return result.Resolve();
        }
    }
}