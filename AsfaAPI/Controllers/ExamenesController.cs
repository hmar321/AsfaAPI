using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenesController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public ExamenesController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Examen>>> GetExamenes()
        {
            // Llama al repositorio para obtener la lista de examenes de la base de datos
            List<Examen> examenes = await _repo.GetExamenesAsync();
            // Devuelve la lista de examenes obtenida
            return examenes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Examen>> GetExamen(int id)
        {
            // Llama al repositorio para obtener un examen especifica por su ID
            Examen examen = await _repo.GetExamenAsync(id);
            // Devuelve la examen obtenida
            return examen;
        }

        [HttpPost]
        public async Task<ActionResult<Examen>> CreateExamen(Examen examen)
        {
            // Llama al repositorio para crear un nuevo examen con los datos proporcionados
            Examen newExamen = await _repo.CreateExamenAsync(DateTime.Now, examen.Fallos, examen.Duracion, examen.Aprobado, examen.IdUsuario);
            // Devuelve la examen creada
            return newExamen;
        }

        [HttpPut]
        public async Task<ActionResult<Examen>> UpdateExamen(Examen examen)
        {
            // Llama al repositorio para actualizar un examen existente con los nuevos datos
            Examen updatedExamen = await _repo.UpdateExamenAsync(examen.IdExamen, examen.Fallos, examen.Duracion, examen.Aprobado, examen.IdUsuario);
            // Devuelve la examen actualizada
            return updatedExamen;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteExamen(int id)
        {
            // Llama al repositorio para eliminar un examen por su ID
            int result = await _repo.DeleteExamenAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
