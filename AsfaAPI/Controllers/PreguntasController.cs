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
        public async Task<ActionResult<List<Pregunta>>> GetPregunta()
        {
            // Llama al repositorio para obtener la lista de preguntas de la base de datos
            List<Pregunta> preguntas = await _repo.GetPreguntasAsync();
            // Devuelve la lista de preguntas obtenida
            return preguntas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pregunta>> GetPregunta(int id)
        {
            // Llama al repositorio para obtener una pregunta especifica por su ID
            Pregunta pregunta = await _repo.GetPreguntaAsync(id);
            // Devuelve la pregunta obtenida
            return pregunta;
        }

        [HttpPost]
        public async Task<ActionResult<Pregunta>> CreatePregunta(Pregunta pregunta)
        {
            // Llama al repositorio para crear una nueva pregunta con los datos proporcionados
            Pregunta newPregunta = await _repo.CreatePreguntaAsync(pregunta.Texto, pregunta.UrlImg, DateTime.Now, pregunta.IdPreguntaCategoria, pregunta.IdDificultad, pregunta.IdApunte);
            // Devuelve la pregunta creada
            return newPregunta;
        }

        [HttpPut]
        public async Task<ActionResult<Pregunta>> UpdatePregunta(Pregunta pregunta)
        {
            // Llama al repositorio para actualizar una pregunta existente con los nuevos datos
            Pregunta updatedPregunta = await _repo.UpdatePreguntaAsync(pregunta.IdPregunta, pregunta.Texto, pregunta.UrlImg, pregunta.IdPreguntaCategoria, pregunta.IdDificultad, pregunta.IdApunte);
            // Devuelve la pregunta actualizada
            return updatedPregunta;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeletePregunta(int id)
        {
            // Llama al repositorio para eliminar una pregunta por su ID
            int result = await _repo.DeletePreguntaAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }

    }
}
