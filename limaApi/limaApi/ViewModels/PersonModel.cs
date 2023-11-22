using limaApi.Models;
using System.Reflection.Metadata.Ecma335;

namespace limaApi.ViewModels
{
    public class PersonModel : Participante
    {
        public int? Pontos { get; set; }
        public string CidadeNome { get; set; }
        public string EstadoNome { get; set; }
    }
}
