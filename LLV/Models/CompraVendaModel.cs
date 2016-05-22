using System;

namespace LLV.Models
{
    public class CompraVendaModel
    {
        public int CompraVendaId { get; set; }
        public int TipoCompraVendaId { get; set; }
        public PessoaModel PessoaVenda { get; set; }
        public PessoaModel PessoaCompra { get; set; }
        public DateTime DataCompraVenda { get; set; }
        public string Observacao { get; set; }
    }
}