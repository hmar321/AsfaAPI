using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestasController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public RespuestasController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Respuesta>>> GetRespuestas()
        {
            // Llama al repositorio para obtener la lista de respuestas de la base de datos
            List<Respuesta> respuestas = await _repo.GetRespuestasAsync();
            // Devuelve la lista de respuestas obtenida
            return respuestas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Respuesta>> GetRespuesta(int id)
        {
            // Llama al repositorio para obtener una respuesta especifica por su ID
            Respuesta respuesta = await _repo.GetRespuestaAsync(id);
            // Devuelve la respuesta obtenida
            return respuesta;
        }

        [HttpPost]
        public async Task<ActionResult<Respuesta>> CreateRespuesta(Respuesta respuesta)
        {
            // Llama al repositorio para crear una nueva respuesta con los datos proporcionados
            Respuesta newRespuesta = await _repo.CreateRespuestaAsync(respuesta.Texto, respuesta.Correcta, respuesta.IdPregunta);
            // Devuelve la respuesta creada
            return newRespuesta;
        }

        [HttpPut]
        public async Task<ActionResult<Respuesta>> UpdateRespuesta(Respuesta respuesta)
        {
            // Llama al repositorio para actualizar una respuesta existente con los nuevos datos
            Respuesta updatedRespuesta = await _repo.UpdateRespuestaAsync(respuesta.IdRespuesta, respuesta.Texto, respuesta.Correcta, respuesta.IdPregunta);
            // Devuelve la respuesta actualizada
            return updatedRespuesta;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteRespuesta(int id)
        {
            // Llama al repositorio para eliminar una respuesta por su ID
            int result = await _repo.DeleteRespuestaAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
