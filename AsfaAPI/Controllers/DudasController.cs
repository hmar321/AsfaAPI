using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DudasController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public DudasController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Duda>>> GetDudas()
        {
            // Llama al repositorio para obtener la lista de dudas de la base de datos
            List<Duda> dudas = await _repo.GetDudasAsync();
            // Devuelve la lista de dudas obtenida
            return dudas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Duda>> GetDuda(int id)
        {
            // Llama al repositorio para obtener una duda especifica por su ID
            Duda duda = await _repo.GetDudaAsync(id);
            // Devuelve la duda obtenida
            return duda;
        }

        [HttpPost]
        public async Task<ActionResult<Duda>> CreateDuda(Duda duda)
        {
            // Llama al repositorio para crear una nueva duda con los datos proporcionados
            Duda newDuda = await _repo.CreateDudaAsync(duda.Texto, DateTime.Now, duda.IdUsuario, duda.IdPregunta, duda.IdResolucion);
            // Devuelve la duda creada
            return newDuda;
        }

        [HttpPut]
        public async Task<ActionResult<Duda>> UpdateDuda(Duda duda)
        {
            // Llama al repositorio para actualizar una duda existente con los nuevos datos
            Duda updatedDuda = await _repo.UpdateDudaAsync(duda.IdDuda, duda.Texto, duda.IdUsuario, duda.IdPregunta, duda.IdResolucion);
            // Devuelve la duda actualizada
            return updatedDuda;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteDuda(int id)
        {
            // Llama al repositorio para eliminar una duda por su ID
            int result = await _repo.DeleteDudaAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
