using System;
using System.Collections.Generic;

namespace limaApi.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Participantes = new HashSet<Participante>();
        }

        public int Id { get; set; }
        public string? Cidade1 { get; set; }
        public int? EstadoId { get; set; }

        public virtual Estado? Estado { get; set; }
        public virtual ICollection<Participante> Participantes { get; set; }
    }
}
