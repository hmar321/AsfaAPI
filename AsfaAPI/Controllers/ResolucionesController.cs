using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolucionesController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public ResolucionesController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Resolucion>>> GetResoluciones()
        {
            // Llama al repositorio para obtener la lista de resoluciones de la base de datos
            List<Resolucion> resoluciones = await _repo.GetResolucionesAsync();
            // Devuelve la lista de resoluciones obtenida
            return resoluciones;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resolucion>> GetResolucion(int id)
        {
            // Llama al repositorio para obtener una resolucion especifica por su ID
            Resolucion resolucion = await _repo.GetResolucionAsync(id);
            // Devuelve la resolucion obtenida
            return resolucion;
        }

        [HttpPost]
        public async Task<ActionResult<Resolucion>> CreateResolucion(Resolucion resolucion)
        {
            // Llama al repositorio para crear una nueva resolucion con los datos proporcionados
            Resolucion newResolucion = await _repo.CreateResolucionAsync(resolucion.Texto, DateTime.Now, resolucion.IdUsuario);
            // Devuelve la resolucion creada
            return newResolucion;
        }

        [HttpPut]
        public async Task<ActionResult<Resolucion>> UpdateResolucion(Resolucion resolucion)
        {
            // Llama al repositorio para actualizar una resolucion existente con los nuevos datos
            Resolucion updatedResolucion = await _repo.UpdateResolucionAsync(resolucion.IdResolucion,resolucion.Texto, resolucion.IdUsuario);
            // Devuelve la resolucion actualizada
            return updatedResolucion;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteResolucion(int id)
        {
            // Llama al repositorio para eliminar una resolucion por su ID
            int result = await _repo.DeleteResolucionAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
