using AsfaAPI.Data;
using AsfaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AsfaAPI.Repositories
{
    public class RepositoryAsfa : IRepositoryAsfa
    {
        private AsfaContext _context;

        public RepositoryAsfa(AsfaContext context)
        {
            _context = context;
        }

        #region ROL
        public async Task<List<Rol>> GetRolsAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Rol> roles = await _context.Roles.ToListAsync();
            // Si la lista es null o esta vacia
            if (roles.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return roles;
            }
        }

        public async Task<Rol> GetRolAsync(int id)
        {
            // Busca el registro existente por ID
            Rol rol = await _context.Roles.FirstOrDefaultAsync(o => o.IdRol == id);
            // Devuelve el registro encontrado o null si no existe
            return rol;
        }

        public async Task<Rol> CreateRolAsync(string nombre, string? descripcion)
        {
            // Obtiene el último registro o null si no hay nada
            Rol ultimo = await _context.Roles.LastOrDefaultAsync();
            // Inicializa el ID con un valor predeterminado de 1
            int id = 1;
            // Si existe al menos un registro establece el siguiente ID
            if (ultimo != null)
            {
                id = ultimo.IdRol + 1;
            }
            // Crear un objeto con los atributos
            var nuevoRol = new Rol
            {
                IdRol = id,
                Nombre = nombre,
                Descripcion = descripcion
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Roles.Add(nuevoRol);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return nuevoRol;
        }

        public async Task<Rol> UpdateRolAsync(int id, string nombre, string? descripcion)
        {
            // Busca el registro existente por ID
            Rol rol = await this.GetRolAsync(id);
            // Actualiza los atributos según los datos recibidos
            if (rol != null)
            {
                rol.Nombre = nombre;
                rol.Descripcion = descripcion;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado
            return rol;
        }

        public async Task<int> DeleteRolAsync(int id)
        {
            // Busca el registro existente por ID
            Rol rol = await this.GetRolAsync(id);
            // Si existe el registro lo elimina
            if (rol != null)
            {
                _context.Roles.Remove(rol);
            }
            // Guarda los cambios en la base de datos y devuelve los registros afectados
            int result = await _context.SaveChangesAsync();
            return result;
        }
        #endregion

        #region USUARIO
        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Usuario> usuarios = await _context.Usuarios.ToListAsync();
            // Si la lista es null o esta vacia
            if (usuarios.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return usuarios;
            }
        }

        public async Task<Usuario> GetUsuarioAsync(int id)
        {
            // Busca el registro existente por ID
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(o => o.IdUsuario == id);
            // Devuelve el registro encontrado o null si no existe
            return usuario;
        }

        public async Task<Usuario> CreateUsuarioAsync(string nombre, string dni, byte[] password, string salt, string? token, DateTime fechaRegistro, int idRol)
        {
            // Obtiene el último registro o null si no hay nada
            Usuario ultimo = await _context.Usuarios.LastOrDefaultAsync();
            // Inicializa el ID con un valor predeterminado de 1
            int id = 1;
            // Si existe al menos un registro establece el siguiente ID
            if (ultimo != null)
            {
                id = ultimo.IdUsuario + 1;
            }
            // Crear un objeto con los atributos
            var nuevoUsuario = new Usuario
            {
                IdUsuario = id,
                Nombre = nombre,
                Dni = dni,
                Password = password,
                Salt = salt,
                Token = token,
                FechaRegistro = fechaRegistro,
                IdRol = idRol
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Usuarios.Add(nuevoUsuario);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return nuevoUsuario;
        }

        public async Task<Usuario> UpdateUsuarioAsync(int id, string nombre, string dni, byte[] password, string salt, string? token, DateTime fechaRegistro, int idRol)
        {
            // Busca el registro existente por ID
            Usuario usuario = await this.GetUsuarioAsync(id);
            // Actualiza los atributos según los datos recibidos
            if (usuario != null)
            {
                usuario.Nombre = nombre;
                usuario.Dni = dni;
                usuario.Password = password;
                usuario.Salt = salt;
                usuario.Token = token;
                usuario.FechaRegistro = fechaRegistro;
                usuario.IdRol = idRol;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado
            return usuario;
        }

        public async Task<int> DeleteUsuarioAsync(int id)
        {
            // Busca el registro existente por ID
            Usuario usuario = await this.GetUsuarioAsync(id);
            // Si existe el registro lo elimina
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            // Guarda los cambios en la base de datos y devuelve los registros afectados
            int result = await _context.SaveChangesAsync();
            return result;
        }
        #endregion

        #region APUNTE
        public async Task<List<Apunte>> GetApuntesAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Apunte> apuntes = await _context.Apuntes.ToListAsync();
            // Si la lista es null o esta vacia
            if (apuntes.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return apuntes;
            }
        }

        public async Task<Apunte> GetApunteAsync(int id)
        {
            // Busca el registro existente por ID
            Apunte apunte = await _context.Apuntes.FirstOrDefaultAsync(o => o.IdApunte == id);
            // Devuelve el registro encontrado o null si no existe
            return apunte;
        }

        public async Task<Apunte> CreateApunteAsync(string texto)
        {
            // Obtiene el último registro o null si no hay nada
            Apunte ultimo = await _context.Apuntes.LastOrDefaultAsync();
            // Inicializa el ID con un valor predeterminado de 1
            int id = 1;
            // Si existe al menos un registro establece el siguiente ID
            if (ultimo != null)
            {
                id = ultimo.IdApunte + 1;
            }
            // Crear un objeto con los atributos
            var nuevoApunte = new Apunte
            {
                IdApunte = id,
                Texto = texto
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Apuntes.Add(nuevoApunte);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return nuevoApunte;
        }

        public async Task<Apunte> UpdateApunteAsync(int id, string texto)
        {
            // Busca el registro existente por ID
            Apunte apunte = await this.GetApunteAsync(id);
            // Actualiza los atributos según los datos recibidos
            if (apunte != null)
            {
                apunte.Texto = texto;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado
            return apunte;
        }

        public async Task<int> DeleteApunteAsync(int id)
        {
            // Busca el registro existente por ID
            Apunte apunte = await this.GetApunteAsync(id);
            // Si existe el registro lo elimina
            if (apunte != null)
            {
                _context.Apuntes.Remove(apunte);
            }
            // Guarda los cambios en la base de datos y devuelve los registros afectados
            int result = await _context.SaveChangesAsync();
            return result;
        }
        #endregion

        #region PREGUNTACATEGORIA
        public async Task<List<PreguntaCategoria>> GetPreguntaCategoriasAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<PreguntaCategoria> apuntes = await _context.PreguntaCategorias.ToListAsync();
            // Si la lista es null o esta vacia
            if (apuntes.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return apuntes;
            }
        }

        public async Task<PreguntaCategoria> GetPreguntaCategoriaAsync(int id)
        {
            // Busca el registro existente por ID
            PreguntaCategoria apunte = await _context.PreguntaCategorias.FirstOrDefaultAsync(o => o.IdPreguntaCategoria == id);
            // Devuelve el registro encontrado o null si no existe
            return apunte;
        }

        public async Task<PreguntaCategoria> CreatePreguntaCategoriaAsync(string nombre, string? descripcion)
        {
            // Obtiene el último registro o null si no hay nada
            PreguntaCategoria ultimo = await _context.PreguntaCategorias.LastOrDefaultAsync();
            // Inicializa el ID con un valor predeterminado de 1
            int id = 1;
            // Si existe al menos un registro establece el siguiente ID
            if (ultimo != null)
            {
                id = ultimo.IdPreguntaCategoria + 1;
            }
            // Crear un objeto con los atributos
            var nuevoPreguntaCategoria = new PreguntaCategoria
            {
                IdPreguntaCategoria = id,
                Nombre = nombre,
                Descripcion = descripcion
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.PreguntaCategorias.Add(nuevoPreguntaCategoria);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return nuevoPreguntaCategoria;
        }

        public async Task<PreguntaCategoria> UpdatePreguntaCategoriaAsync(int id, string nombre, string? descripcion)
        {
            // Busca el registro existente por ID
            PreguntaCategoria apunte = await this.GetPreguntaCategoriaAsync(id);
            // Actualiza los atributos según los datos recibidos
            if (apunte != null)
            {
                apunte.Nombre = nombre;
                apunte.Descripcion = descripcion;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado
            return apunte;
        }

        public async Task<int> DeletePreguntaCategoriaAsync(int id)
        {
            // Busca el registro existente por ID
            PreguntaCategoria apunte = await this.GetPreguntaCategoriaAsync(id);
            // Si existe el registro lo elimina
            if (apunte != null)
            {
                _context.PreguntaCategorias.Remove(apunte);
            }
            // Guarda los cambios en la base de datos y devuelve los registros afectados
            int result = await _context.SaveChangesAsync();
            return result;
        }
        #endregion

        #region PREGUNTA
        public async Task<List<Pregunta>> GetPreguntasAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Pregunta> preguntas = await _context.Preguntas.ToListAsync();
            // Si la lista es null o esta vacia
            if (preguntas.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return preguntas;
            }
        }

        public async Task<Pregunta> GetPreguntaAsync(int id)
        {
            // Busca el registro existente por ID
            Pregunta pregunta = await _context.Preguntas.FirstOrDefaultAsync(o => o.IdPregunta == id);
            // Devuelve el registro encontrado o null si no existe
            return pregunta;
        }

        public async Task<Pregunta> CreatePreguntaAsync(string texto, string? urlImg, DateTime fechaCreacion, int idPreguntaCategoria, int idDificultad, int? idApunte)
        {
            // Obtiene el ultimo registro o null si no hay nada
            Pregunta ultimo = await _context.Preguntas.LastOrDefaultAsync();
            // Inicializa el ID con un valor predeterminado de 1
            int id = 1;
            // Si existe al menos un registro establece el siguiente ID
            if (ultimo != null)
            {
                id = ultimo.IdPregunta + 1;
            }
            // Crear un objeto con los atributos
            var nuevaPregunta = new Pregunta
            {
                IdPregunta = id,
                Texto = texto,
                UrlImg = urlImg,
                FechaCreacion = fechaCreacion,
                IdPreguntaCategoria = idPreguntaCategoria,
                IdDificultad = idDificultad,
                IdApunte = idApunte
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Preguntas.Add(nuevaPregunta);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado creada
            return nuevaPregunta;
        }

        public async Task<Pregunta> UpdatePreguntaAsync(int id, string texto, string? urlImg, DateTime fechaCreacion, int idPreguntaCategoria, int idDificultad, int? idApunte)
        {
            // Busca el registro existente por ID
            Pregunta pregunta = await this.GetPreguntaAsync(id);
            // Actualiza los atributos segun los datos recibidos
            pregunta.Texto = texto;
            pregunta.UrlImg = urlImg;
            pregunta.FechaCreacion = fechaCreacion;
            pregunta.IdPreguntaCategoria = idPreguntaCategoria;
            pregunta.IdDificultad = idDificultad;
            pregunta.IdApunte = idApunte;
            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto actualizado
            return pregunta;
        }

        public async Task<int> DeletePreguntaAsync(int id)
        {
            // Busca el registro existente por ID
            Pregunta pregunta = await this.GetPreguntaAsync(id);
            // Si existe el registro lo elimina
            if (pregunta != null)
            {
                _context.Preguntas.Remove(pregunta);
            }
            // Guarda los cambios en la base de datos y guadamos los registros afectados
            int result = await _context.SaveChangesAsync();
            // Devolvemos los registros afectados
            return result;
        }
        #endregion

    }
}
