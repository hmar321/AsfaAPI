using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaCategoriasController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public PreguntaCategoriasController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PreguntaCategoria>>> GetPreguntaCategorias()
        {
            // Llama al repositorio para obtener la lista de preguntaCategorias de la base de datos
            List<PreguntaCategoria> preguntaCategorias = await _repo.GetPreguntaCategoriasAsync();
            // Devuelve la lista de preguntaCategorias obtenida
            return preguntaCategorias;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntaCategoria>> GetPreguntaCategoria(int id)
        {
            // Llama al repositorio para obtener una preguntaCategoria especifica por su ID
            PreguntaCategoria preguntaCategoria = await _repo.GetPreguntaCategoriaAsync(id);
            // Devuelve la preguntaCategoria obtenida
            return preguntaCategoria;
        }

        [HttpPost]
        public async Task<ActionResult<PreguntaCategoria>> CreatePreguntaCategoria(PreguntaCategoria preguntaCategoria)
        {
            // Llama al repositorio para crear una nueva preguntaCategoria con los datos proporcionados
            PreguntaCategoria newPreguntaCategoria = await _repo.CreatePreguntaCategoriaAsync(preguntaCategoria.Nombre, preguntaCategoria.Descripcion);
            // Devuelve la preguntaCategoria creada
            return newPreguntaCategoria;
        }

        [HttpPut]
        public async Task<ActionResult<PreguntaCategoria>> UpdatePreguntaCategoria(PreguntaCategoria preguntaCategoria)
        {
            // Llama al repositorio para actualizar una preguntaCategoria existente con los nuevos datos
            PreguntaCategoria updatedPreguntaCategoria = await _repo.UpdatePreguntaCategoriaAsync(preguntaCategoria.IdPreguntaCategoria, preguntaCategoria.Nombre, preguntaCategoria.Descripcion);
            // Devuelve la preguntaCategoria actualizada
            return updatedPreguntaCategoria;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeletePreguntaCategoria(int id)
        {
            // Llama al repositorio para eliminar una preguntaCategoria por su ID
            int result = await _repo.DeletePreguntaCategoriaAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
