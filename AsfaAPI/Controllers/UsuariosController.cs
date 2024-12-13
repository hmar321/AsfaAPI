using AsfaAPI.Models;
using AsfaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IRepositoryAsfa _repo;

        public UsuariosController(IRepositoryAsfa repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            // Llama al repositorio para obtener la lista de usuarios de la base de datos
            List<Usuario> usuarios = await _repo.GetUsuariosAsync();
            // Devuelve la lista de usuarios obtenida
            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            // Llama al repositorio para obtener un usuario especifica por su ID
            Usuario usuario = await _repo.GetUsuarioAsync(id);
            // Devuelve la usuario obtenida
            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            // Llama al repositorio para crear un nuevo usuario con los datos proporcionados
            Usuario newUsuario = await _repo.CreateUsuarioAsync(usuario.Nombre, usuario.Dni, usuario.Password, usuario.Salt, usuario.Token, DateTime.Now, usuario.IdRol);
            // Devuelve la usuario creada
            return newUsuario;
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> UpdateUsuario(Usuario usuario)
        {
            // Llama al repositorio para actualizar un usuario existente con los nuevos datos
            Usuario updatedUsuario = await _repo.UpdateUsuarioAsync(usuario.IdUsuario, usuario.Nombre, usuario.Dni, usuario.Password, usuario.Salt, usuario.Token, usuario.IdRol);
            // Devuelve la usuario actualizada
            return updatedUsuario;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteUsuario(int id)
        {
            // Llama al repositorio para eliminar un usuario por su ID
            int result = await _repo.DeleteUsuarioAsync(id);
            // Devuelve numero de registros afectados
            return result;
        }
    }
}
