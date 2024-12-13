using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApuntesController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public ApuntesController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Apunte>>> GetApuntes()
        {
            // Llama al repositorio para obtener la lista de apuntes de la base de datos
            List<Apunte> apuntes = await _repo.GetApuntesAsync();
            // Devuelve la lista de apuntes obtenida
            return apuntes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Apunte>> GetApunte(int id)
        {
            // Llama al repositorio para obtener un apunte especifica por su ID
            Apunte apunte = await _repo.GetApunteAsync(id);
            // Devuelve la apunte obtenida
            return apunte;
        }

        [HttpPost]
        public async Task<ActionResult<Apunte>> CreateApunte(Apunte apunte)
        {
            // Llama al repositorio para crear un nuevo apunte con los datos proporcionados
            Apunte newApunte = await _repo.CreateApunteAsync(apunte.Texto);
            // Devuelve la apunte creada
            return newApunte;
        }

        [HttpPut]
        public async Task<ActionResult<Apunte>> UpdateApunte(Apunte apunte)
        {
            // Llama al repositorio para actualizar un apunte existente con los nuevos datos
            Apunte updatedApunte = await _repo.UpdateApunteAsync(apunte.IdApunte, apunte.Texto);
            // Devuelve la apunte actualizada
            return updatedApunte;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteApunte(int id)
        {
            // Llama al repositorio para eliminar un apunte por su ID
            int result = await _repo.DeleteApunteAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
