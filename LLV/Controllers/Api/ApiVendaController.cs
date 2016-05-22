using LLV.DAL;
using LLV.Models;
using System.Web.Http;

namespace LLV.Controllers.Api
{
    [RoutePrefix("api/venda")]
    public class ApiVendaController : ApiController
    {
        [HttpGet]
        [Route("carregar/{CompraVendaId:int}")]
        public ResultModel<CompraVendaModel> GetVenda(int CompraVendaId)
        {
            var result = new Result<CompraVendaModel>();

            CompraVendaModel venda = new CompraVendaDAL().CarregarCompraVenda(CompraVendaId);

            if (null == venda)
                return result.Empty();

            result.SetResult(venda);

            return result.Resolve();
        }
    }
}