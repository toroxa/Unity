using LLV.Models;
using System.Collections.Generic;
using System.Linq;
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
            var menus = new[]
            {
                new MenuModel() { Id = 1, Description = "Home", URL = "/", ClassIcon = "menu-icon glyphicon glyphicon-home" },
                //new MenuModel() { Id = 2, Description = "Conf. de Parâmetros", URL = "/parametro", ClassIcon = "menu-icon glyphicon glyphicon-tasks" },
                new MenuModel() { Id = 3, Description = "Ordem de Serviço", URL = "/os", ClassIcon = "menu-icon glyphicon glyphicon-wrench" },
            };

            if (null == menus)
                return result.Empty();

            var menuModels = menus.OrderBy(menuModel => menuModel.Id);

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