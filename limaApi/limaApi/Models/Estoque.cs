using System;
using System.Collections.Generic;

namespace limaApi.Models
{
    public partial class Estoque
    {
        public int Id { get; set; }
        public int? ProdutoId { get; set; }
        public int? LojaId { get; set; }
        public int? Quantidade { get; set; }

        public virtual Loja? Loja { get; set; }
        public virtual Produto? Produto { get; set; }
    }
}
