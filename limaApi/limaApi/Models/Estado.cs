using System;
using System.Collections.Generic;

namespace limaApi.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        public int Id { get; set; }
        public string? Estado1 { get; set; }
        public string? Sigla { get; set; }
        public int? RegiaoId { get; set; }

        public virtual Regiao? Regiao { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
