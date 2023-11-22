using System;
using System.Collections.Generic;

namespace limaApi.Models
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string? TipoEvento1 { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
