using LLV.DAL;
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
        [Route("listar/{GrupoId:int}")]
        public ResultModel<IEnumerable<PessoaModel>> GetPessoas(int GrupoId)
        {
            var result = new Result<IEnumerable<PessoaModel>>();
            IList<PessoaModel> pessoas = new PessoaDAL().ListarPessoas(GrupoId);

            if (null == pessoas || pessoas.Count == 0)
                return result.Empty();

            var pessoaModels = pessoas.OrderBy(pessoaModel => pessoaModel.Nome);
            result.SetResult(pessoaModels);
            return result.Resolve();
        }

        [HttpGet]
        [Route("carregar/{PessoaId:int}")]
        public ResultModel<PessoaModel> GetPessoa(int PessoaId)
        {
            var result = new Result<PessoaModel>();
            PessoaModel pessoa = new PessoaDAL().CarregarPessoa(PessoaId);

            if (null == pessoa)
                return result.Empty();

            result.SetResult(pessoa);
            return result.Resolve();
        }
    }
}