using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLV.Models
{
    public class MenuModel
    {
        //public string Action { get; set; }
        //public string Controller { get; set; }
        public int Id { get; set; }
        public string ClassIcon { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

        public List<MenuModel> Menus { get; set; }
    }
}