using LLV.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LLV.Controllers.Api
{
    [RoutePrefix("api/pessoa")]
    public class ApiPessoaController : ApiController
    {
        [HttpGet]
        [Route("listar/{grupoid:int}")]
        public ResultModel<IEnumerable<PessoaModel>> GetPessoas(int grupoid)
        {
            var result = new Result<IEnumerable<PessoaModel>>();
            var pessoas = new[]
            {
                new PessoaModel() { Id = 1, Codigo = "1", Nome = "VINICIUS DE SIQUEIRA CAMPOS" },
            };

            if (null == pessoas)
                return result.Empty();

            var pessoaModels = pessoas.OrderBy(pessoaModel => pessoaModel.Nome);

            result.SetResult(pessoaModels);

            return result.Resolve();
        }
    }
}