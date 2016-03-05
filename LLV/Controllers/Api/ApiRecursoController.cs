using LLV.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LLV.Controllers.Api
{
    [RoutePrefix("api/recurso")]
    public class ApiRecursoController : ApiController
    {
        [HttpGet]
        [Route("listar")]
        public ResultModel<IEnumerable<RecursoModel>> GetRecursos()
        {
            var result = new Result<IEnumerable<RecursoModel>>();
            var recursos = new[]
            {
                new RecursoModel() { Id = 0, Codigo = "1", Nome = "DVD PIONNER LCD 7 POL" },
            };

            if (null == recursos)
                return result.Empty();

            var recursoModels = recursos.OrderBy(recursoModel => recursoModel.Nome);

            result.SetResult(recursoModels);

            return result.Resolve();
        }
    }
}