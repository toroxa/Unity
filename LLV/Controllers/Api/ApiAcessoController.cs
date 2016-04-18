using LLV.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LLV.Controllers.Api
{
    [RoutePrefix("api/acesso")]
    public class ApiAcessoController : ApiController
    {
        [HttpGet]
        [Route("listar-menus")]
        public ResultModel<IEnumerable<MenuModel>> GetMenus()
        {
            var result = new Result<IEnumerable<MenuModel>>();

            //var filhosCadastro2 = new List<MenuModel>();
            //filhosCadastro2.Add(new MenuModel() { Id = 6, Description = "Ordem de Serviço 2", URL = "/os", ClassIcon = "menu-icon glyphicon glyphicon-wrench", Ordem = 1 });

            var filhosCadastro = new List<MenuModel>();
            filhosCadastro.Add(new MenuModel() { Id = 2, Description = "Home", URL = "/inicio", ClassIcon = "menu-icon glyphicon glyphicon-home", Ordem = 2 });
            filhosCadastro.Add(new MenuModel() { Id = 6, Description = "separator", URL = null, ClassIcon = null, Ordem = 3 });
            filhosCadastro.Add(new MenuModel() { Id = 4, Description = "Ordem de Serviço", URL = "/os", ClassIcon = "menu-icon glyphicon glyphicon-wrench", Ordem = 4 });
            //filhosCadastro.Add(new MenuModel() { Id = 5, Description = "Cadastro 2", URL = null, ClassIcon = null, Ordem = 0, Menus = filhosCadastro2 });

            var menus = new[] {
                new MenuModel() { Id = 1, Description = "Cadastros", URL = null, ClassIcon = null, Menus = filhosCadastro, Ordem = 1 },
            };

            if (null == menus)
                return result.Empty();

            var menuModels = menus.OrderBy(menuModel => menuModel.Ordem);

            result.SetResult(menuModels);

            return result.Resolve();
        }

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}