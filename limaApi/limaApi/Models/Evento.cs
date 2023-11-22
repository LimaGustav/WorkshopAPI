using System;
using System.Collections.Generic;

namespace limaApi.Models
{
    public partial class Evento
    {
        public Evento()
        {
            ParticipantesEventos = new HashSet<ParticipantesEvento>();
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public string? Evento1 { get; set; }
        public int? TipoId { get; set; }

        public virtual TipoEvento? Tipo { get; set; }
        public virtual ICollection<ParticipantesEvento> ParticipantesEventos { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
