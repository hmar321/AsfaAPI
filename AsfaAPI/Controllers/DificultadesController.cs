using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DificultadesController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public DificultadesController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dificultad>>> GetDificultad()
        {
            // Llama al repositorio para obtener la lista de dificultades de la base de datos
            List<Dificultad> dificultades = await _repo.GetDificultadesAsync();
            // Devuelve la lista de dificultades obtenida
            return dificultades;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dificultad>> GetDificultad(int id)
        {
            // Llama al repositorio para obtener una dificultad especifica por su ID
            Dificultad dificultad = await _repo.GetDificultadAsync(id);
            // Devuelve la dificultad obtenida
            return dificultad;
        }

        [HttpPost]
        public async Task<ActionResult<Dificultad>> CreateDificultad(Dificultad dificultad)
        {
            // Llama al repositorio para crear una nueva dificultad con los datos proporcionados
            Dificultad newDificultad = await _repo.CreateDificultadAsync(dificultad.Nombre, dificultad.Descripcion);
            // Devuelve la dificultad creada
            return newDificultad;
        }

        [HttpPut]
        public async Task<ActionResult<Dificultad>> UpdateDificultad(Dificultad dificultad)
        {
            // Llama al repositorio para actualizar una dificultad existente con los nuevos datos
            Dificultad updatedDificultad = await _repo.UpdateDificultadAsync(dificultad.IdDificultad, dificultad.Nombre, dificultad.Descripcion);
            // Devuelve la dificultad actualizada
            return updatedDificultad;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteDificultad(int id)
        {
            // Llama al repositorio para eliminar una dificultad por su ID
            int result = await _repo.DeleteDificultadAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
