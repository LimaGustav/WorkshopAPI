using limaApi.Contexts;
using limaApi.Models;
using limaApi.Repositories;
using limaApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace limaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
       
        RankingRepository repository = new RankingRepository();
       
        [HttpGet]
        public IActionResult GetRanking()
        {

            var lista = repository.CalculateRanking();


            return Ok(lista);
        }

        [HttpGet(">{score}")]
        public IActionResult GetByMinimumScore(int score)
        {
            var lista = repository.CalculateRanking().Where(x => x.Pontos > score);


            return Ok(lista);
        }
        [HttpGet("<{score}")]
        public IActionResult GetByMaximumScore(int score)
        {
            var lista = repository.CalculateRanking().Where(x => x.Pontos < score);


            return Ok(lista);
        }

        [HttpGet(">={score}")]
        public IActionResult GetByMinimumScoreInclusive(int score)
        {
            var lista = repository.CalculateRanking().Where(x => x.Pontos >= score);


            return Ok(lista);
        }
        [HttpGet("<={score}")]
        public IActionResult GetByMaximumScoreInclusive(int score)
        {
            var lista = repository.CalculateRanking().Where(x => x.Pontos <= score);


            return Ok(lista);
        }

        [HttpGet("+{estado}")]
        public IActionResult GetByEstado(string estado)
        {
            var lista = repository.CalculateRanking().Where(x => x.EstadoNome.ToLower().StartsWith(estado.Substring(0,2)));


            return Ok(lista);
        }

        [HttpGet("%{nome}")]
        public IActionResult GetByEndName(string nome)
        {
            var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().EndsWith(nome.ToLower()));


            return Ok(lista);
        }

        [HttpGet("{nome}%")]
        public IActionResult GetByStartName(string nome)
        {
            var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().StartsWith(nome.ToLower()));


            return Ok(lista);
        }

        [HttpGet("%{nome}%")]
        public IActionResult GetByName(string nome)
        {
            var lista = repository.CalculateRanking().Where(x => x.Nome.ToLower().Contains(nome.ToLower()));


            return Ok(lista);
        }

        [HttpGet("!>{type}")]
        public IActionResult OrderAscName(string type)
        {
            if (type == "PA")
                return Ok(repository.CalculateRanking().OrderBy(x => x.Nome));

            else if (type == "PO")
                return Ok(repository.CalculateRanking().OrderBy(x => x.Pontos));

            else return NotFound();
        }

        [HttpGet("!<{type}")]
        public IActionResult OrderDescName(string type)
        {
            if (type == "PA")
                return Ok(repository.CalculateRanking().OrderByDescending(x => x.Nome));
            

            else if (type == "PO")
                return Ok(repository.CalculateRanking().OrderByDescending(x => x.Pontos));

            else return NotFound();
        }
    }
}
