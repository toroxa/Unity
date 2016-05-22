using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLV.Models;
using System.Data.SqlClient;
using System.Data;

namespace LLV.DAL
{
    public class PessoaDAL
    {
        public PessoaModel CarregarPessoa(int PessoaId)
        {
            PessoaModel pessoa = null;
            using (SqlConnection conn = new SqlConnection(Util.Config.RetornaConexao("ControleVendas")))
            {
                using (SqlCommand comm = new SqlCommand("USP_SEL_Pessoa", conn))
                {
                    conn.Open();
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add("@PessoaId", SqlDbType.Int).Value = PessoaId;
                    using (SqlDataReader drPessoa = comm.ExecuteReader())
                    {
                        if (drPessoa.HasRows && drPessoa.Read())
                        {
                            pessoa = new PessoaModel() { PessoaId = (int)drPessoa["PessoaId"], Nome = drPessoa["Nome"].ToString(), DisplayName = drPessoa["PessoaId"].ToString() + " - " + drPessoa["Nome"].ToString() };
                        }
                    }
                }
            }
            return pessoa;
        }

        public IList<PessoaModel> ListarPessoas(int grupoid)
        {
            IList<PessoaModel> pessoas = null;
            using (SqlConnection conn = new SqlConnection(Util.Config.RetornaConexao("ControleVendas")))
            {
                using (SqlCommand comm = new SqlCommand("USP_SEL_PessoaGrupo", conn))
                {
                    conn.Open();
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add("@GrupoId", SqlDbType.Int).Value = grupoid;
                    using (SqlDataReader drPessoas = comm.ExecuteReader())
                    {
                        while (drPessoas.HasRows && drPessoas.Read())
                        {
                            if (pessoas == null)
                                pessoas = new List<PessoaModel>();
                            pessoas.Add(new PessoaModel() { PessoaId = (int)drPessoas["PessoaId"], Nome = drPessoas["Nome"].ToString() });
                        }
                    }
                }
            }
            return pessoas;
        }
    }
}