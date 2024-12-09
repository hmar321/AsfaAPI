using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public PreguntasController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pregunta>>> GetPreguntas()
        {
            List<Pregunta> preguntas = await _repo.GetPreguntas();
            return preguntas;
        }
    }
}
