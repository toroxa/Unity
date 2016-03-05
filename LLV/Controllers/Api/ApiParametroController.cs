using LLV.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LLV.Controllers.Api
{
    [RoutePrefix("api/parametro")]
    public class ApiParametroController : ApiController
    {
        [HttpGet]
        [Route("listar")]
        public ResultModel<IEnumerable<ParametroModel>> GetParametros()
        {
            var result = new Result<IEnumerable<ParametroModel>>();
            var parametros = new[]
            {
                new ParametroModel() { Chave = "SenhaMaster", Valor = "123456" },
                new ParametroModel() { Chave = "Desconto", Valor = "15" },
            };

            if (null == parametros)
                return result.Empty();

            var parametroModels = parametros.OrderBy(parametroModel => parametroModel.Chave);

            result.SetResult(parametroModels);

            return result.Resolve();
        }
    }
}