using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LLV.Util
{
    public static class Config
    {
        public static void Configurar()
        {
            strConexao = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;
        }

        private static string strConexao { get; set; }

        public static string RetornaConexao(string DataBase)
        {
            return string.Format(strConexao, DataBase);
        }
    }
}