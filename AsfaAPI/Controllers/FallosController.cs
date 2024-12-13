using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FallosController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public FallosController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fallo>>> GetFallos()
        {
            // Llama al repositorio para obtener la lista de fallos de la base de datos
            List<Fallo> fallos = await _repo.GetFallosAsync();
            // Devuelve la lista de fallos obtenida
            return fallos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fallo>> GetFallo(int id)
        {
            // Llama al repositorio para obtener un fallo especifica por su ID
            Fallo fallo = await _repo.GetFalloAsync(id);
            // Devuelve la fallo obtenida
            return fallo;
        }

        [HttpPost]
        public async Task<ActionResult<Fallo>> CreateFallo(Fallo fallo)
        {
            // Llama al repositorio para crear un nuevo fallo con los datos proporcionados
            Fallo newFallo = await _repo.CreateFalloAsync(fallo.IdUsuario, fallo.IdPregunta);
            // Devuelve la fallo creada
            return newFallo;
        }

        [HttpPut]
        public async Task<ActionResult<Fallo>> UpdateFallo(Fallo fallo)
        {
            // Llama al repositorio para actualizar un fallo existente con los nuevos datos
            Fallo updatedFallo = await _repo.UpdateFalloAsync(fallo.IdFallo, fallo.IdUsuario, fallo.IdPregunta);
            // Devuelve la fallo actualizada
            return updatedFallo;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteFallo(int id)
        {
            // Llama al repositorio para eliminar un fallo por su ID
            int result = await _repo.DeleteFalloAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
