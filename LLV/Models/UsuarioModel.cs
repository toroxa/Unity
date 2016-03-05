using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LLV.Models
{
    public class UsuarioModel
    {
        public string msgAlerta { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        public string Nome { get; private set; }
        public string Foto { get; set; }
        public string Email { get; private set; }
        //public List<MenuModel> Menus { get; set; }

        public bool EfetuaLogin(ref string msgAlerta)
        {
            if (AutenticaUsuario())
            {
                HttpContext.Current.Session.Add("logado", this);
                return true;
            }

            msgAlerta = this.msgAlerta;
            return false;
        }

        public void EfetuaLogoff()
        {
            HttpContext.Current.Session.Remove("logado");
        }

        private bool AutenticaUsuario()
        {
            if (this.Login == "vinicius.campos" && this.Senha == "123")
            {
                this.Nome = "Vinicius de Siqueira Campos";
                this.Foto = "Content/assets/img/avatars/blank-avatar.jpg";
                this.Email = "vsiqueirac@gmail.com";
                //this.Menus = new List<MenuModel>();
                //this.Menus.Add(new MenuModel() { Description = "Home", URL = "/Home/Home", ClassIcon = "menu-icon glyphicon glyphicon-home" });
                //this.Menus.Add(new MenuModel() { Description = "Conf. de Parâmetros", URL = "/Home/Parametro", ClassIcon = "menu-icon glyphicon glyphicon-tasks" });
                return true;
            }
            else
            {
                this.Login = string.Empty;
                this.Senha = string.Empty;
                this.msgAlerta = "Usuário ou Senha inválidos!";
                return false;
            }
        }
    }
}