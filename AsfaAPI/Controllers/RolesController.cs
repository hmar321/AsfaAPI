using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public RolesController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetRoles()
        {
            // Llama al repositorio para obtener la lista de roles de la base de datos
            List<Rol> roles = await _repo.GetRolesAsync();
            // Devuelve la lista de roles obtenida
            return roles;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            // Llama al repositorio para obtener un rol especifica por su ID
            Rol rol = await _repo.GetRolAsync(id);
            // Devuelve la rol obtenida
            return rol;
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> CreateRol(Rol rol)
        {
            // Llama al repositorio para crear un nuevo rol con los datos proporcionados
            Rol newRol = await _repo.CreateRolAsync(rol.Nombre, rol.Descripcion);
            // Devuelve la rol creada
            return newRol;
        }

        [HttpPut]
        public async Task<ActionResult<Rol>> UpdateRol(Rol rol)
        {
            // Llama al repositorio para actualizar un rol existente con los nuevos datos
            Rol updatedRol = await _repo.UpdateRolAsync(rol.IdRol, rol.Nombre, rol.Descripcion);
            // Devuelve la rol actualizada
            return updatedRol;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteRol(int id)
        {
            // Llama al repositorio para eliminar un rol por su ID
            int result = await _repo.DeleteRolAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
