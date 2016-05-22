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
    class CompraVendaDAL
    {
        public CompraVendaModel CarregarCompraVenda(int CompraVendaId, bool CarregarFilhos = true)
        {
            CompraVendaModel CompraVenda = null;
            using (SqlConnection conn = new SqlConnection(Util.Config.RetornaConexao("ControleVendas")))
            {
                using (SqlCommand comm = new SqlCommand("USP_SEL_CompraVenda", conn))
                {
                    conn.Open();
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add("@CompraVendaId", SqlDbType.Int).Value = CompraVendaId;
                    using (SqlDataReader drVenda = comm.ExecuteReader())
                    {
                        if (drVenda.HasRows && drVenda.Read())
                        {
                            PessoaModel PessoaCompra = null;
                            PessoaModel PessoaVenda = null;
                            if (CarregarFilhos)
                            {
                                PessoaCompra = new PessoaDAL().CarregarPessoa((int)drVenda["PessoaCompraId"]);
                                PessoaVenda = new PessoaDAL().CarregarPessoa((int)drVenda["PessoaVendaId"]);
                            }
                            CompraVenda = new CompraVendaModel() { CompraVendaId = (int)drVenda["CompraVendaId"], DataCompraVenda = (DateTime)drVenda["DataCompraVenda"], PessoaCompra = PessoaCompra, PessoaVenda = PessoaVenda, TipoCompraVendaId = (int)drVenda["TipoCompraVendaId"], Observacao = drVenda["Observacao"].ToString() };
                        }
                    }
                }
            }
            return CompraVenda;
        }
    }
}
