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
        public async Task<List<Rol>> GetRolesAsync()
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
            // Cuenta el numero de registros
            int id = await _context.Roles.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            Rol newRol = new Rol
            {
                IdRol = id,
                Nombre = nombre,
                Descripcion = descripcion
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Roles.Add(newRol);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return newRol;
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
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
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
            // Cuenta el numero de registros
            int id = await _context.Usuarios.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            Usuario newUsuario = new Usuario
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
            _context.Usuarios.Add(newUsuario);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return newUsuario;
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
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
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
            // Cuenta el numero de registros
            int id = await _context.Apuntes.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                id += 1;
            }
            else
            {

            }
            // Crear un objeto con los atributos
            Apunte newApunte = new Apunte
            {
                IdApunte = id,
                Texto = texto
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Apuntes.Add(newApunte);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return newApunte;
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
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (apunte != null)
            {
                _context.Apuntes.Remove(apunte);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
            return result;
        }
        #endregion

        #region PREGUNTACATEGORIA
        public async Task<List<PreguntaCategoria>> GetPreguntaCategoriasAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<PreguntaCategoria> preguntaCategorias = await _context.PreguntaCategorias.ToListAsync();
            // Si la lista es null o esta vacia
            if (preguntaCategorias.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return preguntaCategorias;
            }
        }

        public async Task<PreguntaCategoria> GetPreguntaCategoriaAsync(int id)
        {
            // Busca el registro existente por ID
            PreguntaCategoria preguntaCategoria = await _context.PreguntaCategorias.FirstOrDefaultAsync(o => o.IdPreguntaCategoria == id);
            // Devuelve el registro encontrado o null si no existe
            return preguntaCategoria;
        }

        public async Task<PreguntaCategoria> CreatePreguntaCategoriaAsync(string nombre, string? descripcion)
        {
            // Cuenta el numero de registros
            int id = await _context.PreguntaCategorias.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            PreguntaCategoria newPreguntaCategoria = new PreguntaCategoria
            {
                IdPreguntaCategoria = id,
                Nombre = nombre,
                Descripcion = descripcion
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.PreguntaCategorias.Add(newPreguntaCategoria);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return newPreguntaCategoria;
        }

        public async Task<PreguntaCategoria> UpdatePreguntaCategoriaAsync(int id, string nombre, string? descripcion)
        {
            // Busca el registro existente por ID
            PreguntaCategoria preguntaCategoria = await this.GetPreguntaCategoriaAsync(id);
            // Actualiza los atributos según los datos recibidos
            if (preguntaCategoria != null)
            {
                preguntaCategoria.Nombre = nombre;
                preguntaCategoria.Descripcion = descripcion;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado
            return preguntaCategoria;
        }

        public async Task<int> DeletePreguntaCategoriaAsync(int id)
        {
            // Busca el registro existente por ID
            PreguntaCategoria preguntaCategoria = await this.GetPreguntaCategoriaAsync(id);
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (preguntaCategoria != null)
            {
                _context.PreguntaCategorias.Remove(preguntaCategoria);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
            return result;
        }
        #endregion

        #region DIFICULTAD
        public async Task<List<Dificultad>> GetDificultadesAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Dificultad> dificultades = await _context.Dificultades.ToListAsync();
            // Si la lista es null o esta vacia
            if (dificultades.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return dificultades;
            }
        }

        public async Task<Dificultad> GetDificultadAsync(int id)
        {
            // Busca el registro existente por ID
            Dificultad dificultad = await _context.Dificultades.FirstOrDefaultAsync(o => o.IdDificultad == id);
            // Devuelve el registro encontrado o null si no existe
            return dificultad;
        }

        public async Task<Dificultad> CreateDificultadAsync(string nombre, string? descripcion)
        {
            // Cuenta el numero de registros
            int id = await _context.Dificultades.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            Dificultad newDificultad = new Dificultad
            {
                IdDificultad = id,
                Nombre = nombre,
                Descripcion = descripcion
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Dificultades.Add(newDificultad);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado
            return newDificultad;
        }

        public async Task<Dificultad> UpdateDificultadAsync(int id, string nombre, string? descripcion)
        {
            // Busca el registro existente por ID
            Dificultad dificultad = await this.GetDificultadAsync(id);
            // Actualiza los atributos según los datos recibidos
            if (dificultad != null)
            {
                dificultad.Nombre = nombre;
                dificultad.Descripcion = descripcion;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado
            return dificultad;
        }

        public async Task<int> DeleteDificultadAsync(int id)
        {
            // Busca el registro existente por ID
            Dificultad dificultad = await this.GetDificultadAsync(id);
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (dificultad != null)
            {
                _context.Dificultades.Remove(dificultad);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
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
            int id = await _context.Preguntas.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            Pregunta newPregunta = new Pregunta
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
            _context.Preguntas.Add(newPregunta);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado creada
            return newPregunta;
        }

        public async Task<Pregunta> UpdatePreguntaAsync(int id, string texto, string? urlImg, int idPreguntaCategoria, int idDificultad, int? idApunte)
        {
            // Busca el registro existente por ID
            Pregunta pregunta = await this.GetPreguntaAsync(id);
            // Actualiza los atributos segun los datos recibidos
            pregunta.Texto = texto;
            pregunta.UrlImg = urlImg;
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

        #region DUDA
        public async Task<List<Duda>> GetDudasAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Duda> dudas = await _context.Dudas.ToListAsync();
            // Si la lista es null o esta vacia
            if (dudas.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return dudas;
            }
        }

        public async Task<Duda> GetDudaAsync(int id)
        {
            // Busca el registro existente por ID
            Duda duda = await _context.Dudas.FirstOrDefaultAsync(o => o.IdDuda == id);
            // Devuelve el registro encontrado o null si no existe
            return duda;
        }

        public async Task<Duda> CreateDudaAsync(string texto, DateTime fechaCreacion, int idUsuario, int idPregunta, int? idResolucion)
        {
            // Obtiene el ultimo registro o null si no hay nada
            int id = await _context.Dudas.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            var newDuda = new Duda
            {
                IdDuda = id,
                Texto = texto,
                FechaCreacion = fechaCreacion,
                IdUsuario = idUsuario,
                IdPregunta = idPregunta,
                IdResolucion = idResolucion
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Dudas.Add(newDuda);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado creada
            return newDuda;
        }

        public async Task<Duda> UpdateDudaAsync(int id, string texto, int idUsuario, int idPregunta, int? idResolucion)
        {
            // Busca el registro existente por ID
            Duda duda = await this.GetDudaAsync(id);
            // Si el objeto no es null
            if (duda != null)
            {
                // Actualiza los atributos segun los datos recibidos
                duda.Texto = texto;
                duda.IdUsuario = idUsuario;
                duda.IdPregunta = idPregunta;
                duda.IdResolucion = idResolucion;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado o null si no se encontro
            return duda;
        }

        public async Task<int> DeleteDudaAsync(int id)
        {
            // Busca el registro existente por ID
            Duda duda = await this.GetDudaAsync(id);
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (duda != null)
            {
                _context.Dudas.Remove(duda);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
            return result;
        }
        #endregion

        #region EXAMEN
        public async Task<List<Examen>> GetExamenesAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Examen> examenes = await _context.Examenes.ToListAsync();
            // Si la lista es null o esta vacia
            if (examenes.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return examenes;
            }
        }

        public async Task<Examen> GetExamenAsync(int id)
        {
            // Busca el registro existente por ID
            Examen examen = await _context.Examenes.FirstOrDefaultAsync(o => o.IdExamen == id);
            // Devuelve el registro encontrado o null si no existe
            return examen;
        }

        public async Task<Examen> CreateExamenAsync(DateTime fecha, int fallos, int duracion, bool aprobado, int idUsuario)
        {
            // Obtiene el ultimo registro o null si no hay nada
            int id = await _context.Examenes.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            var newExamen = new Examen
            {
                IdExamen = id,
                Fecha = fecha,
                Fallos = fallos,
                Duracion = duracion,
                Aprobado = aprobado,
                IdUsuario = idUsuario
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Examenes.Add(newExamen);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado creada
            return newExamen;
        }

        public async Task<Examen> UpdateExamenAsync(int id, int fallos, int duracion, bool aprobado, int idUsuario)
        {
            // Busca el registro existente por ID
            Examen examen = await this.GetExamenAsync(id);
            // Si el objeto no es null
            if (examen != null)
            {
                // Actualiza los atributos segun los datos recibidos
                examen.Fallos = fallos;
                examen.Duracion = duracion;
                examen.Aprobado = aprobado;
                examen.IdUsuario = idUsuario;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado o null si no se encontro
            return examen;
        }

        public async Task<int> DeleteExamenAsync(int id)
        {
            // Busca el registro existente por ID
            Examen examen = await this.GetExamenAsync(id);
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (examen != null)
            {
                _context.Examenes.Remove(examen);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
            return result;
        }
        #endregion

        #region FALLO
        public async Task<List<Fallo>> GetFallosAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Fallo> fallos = await _context.Fallos.ToListAsync();
            // Si la lista es null o esta vacia
            if (fallos.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return fallos;
            }
        }

        public async Task<Fallo> GetFalloAsync(int id)
        {
            // Busca el registro existente por ID
            Fallo fallo = await _context.Fallos.FirstOrDefaultAsync(o => o.IdFallo == id);
            // Devuelve el registro encontrado o null si no existe
            return fallo;
        }

        public async Task<Fallo> CreateFalloAsync(int idUsuario, int idPregunta)
        {
            // Obtiene el ultimo registro o null si no hay nada
            int id = await _context.Fallos.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            var newFallo = new Fallo
            {
                IdFallo = id,
                IdUsuario = idUsuario,
                IdPregunta = idPregunta
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Fallos.Add(newFallo);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado creada
            return newFallo;
        }

        public async Task<Fallo> UpdateFalloAsync(int id, int idUsuario, int idPregunta)
        {
            // Busca el registro existente por ID
            Fallo fallo = await this.GetFalloAsync(id);
            // Si el objeto no es null
            if (fallo != null)
            {
                // Actualiza los atributos segun los datos recibidos
                fallo.IdUsuario = idUsuario;
                fallo.IdPregunta = idPregunta;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado o null si no se encontro
            return fallo;
        }

        public async Task<int> DeleteFalloAsync(int id)
        {
            // Busca el registro existente por ID
            Fallo fallo = await this.GetFalloAsync(id);
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (fallo != null)
            {
                _context.Fallos.Remove(fallo);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
            return result;
        }
        #endregion

        #region RESOLUCION
        public async Task<List<Resolucion>> GetResolucionesAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Resolucion> resoluciones = await _context.Resoluciones.ToListAsync();
            // Si la lista es null o esta vacia
            if (resoluciones.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return resoluciones;
            }
        }

        public async Task<Resolucion> GetResolucionAsync(int id)
        {
            // Busca el registro existente por ID
            Resolucion resolucion = await _context.Resoluciones.FirstOrDefaultAsync(o => o.IdResolucion == id);
            // Devuelve el registro encontrado o null si no existe
            return resolucion;
        }

        public async Task<Resolucion> CreateResolucionAsync(string texto, DateTime fechaCreacion, int idUsuario)
        {
            // Obtiene el ultimo registro o null si no hay nada
            int id = await _context.Resoluciones.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            var newResolucion = new Resolucion
            {
                IdResolucion = id,
                Texto = texto,
                FechaCreacion = fechaCreacion,
                IdUsuario = idUsuario
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Resoluciones.Add(newResolucion);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado creada
            return newResolucion;
        }

        public async Task<Resolucion> UpdateResolucionAsync(int id, string texto, int idUsuario)
        {
            // Busca el registro existente por ID
            Resolucion resolucion = await this.GetResolucionAsync(id);
            // Si el objeto no es null
            if (resolucion != null)
            {
                // Actualiza los atributos segun los datos recibidos
                resolucion.Texto = texto;
                resolucion.IdUsuario = idUsuario;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado o null si no se encontro
            return resolucion;
        }

        public async Task<int> DeleteResolucionAsync(int id)
        {
            // Busca el registro existente por ID
            Resolucion resolucion = await this.GetResolucionAsync(id);
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (resolucion != null)
            {
                _context.Resoluciones.Remove(resolucion);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
            return result;
        }
        #endregion

        #region RESPUESTA
        public async Task<List<Respuesta>> GetRespuestasAsync()
        {
            // Recupera una lista con los registros de la base de datos
            List<Respuesta> respuestas = await _context.Respuestas.ToListAsync();
            // Si la lista es null o esta vacia
            if (respuestas.IsNullOrEmpty())
            {
                // Devuelve null
                return null;
            }
            else
            {
                // Devuelve la lista
                return respuestas;
            }
        }

        public async Task<Respuesta> GetRespuestaAsync(int id)
        {
            // Busca el registro existente por ID
            Respuesta respuesta = await _context.Respuestas.FirstOrDefaultAsync(o => o.IdRespuesta == id);
            // Devuelve el registro encontrado o null si no existe
            return respuesta;
        }

        public async Task<Respuesta> CreateRespuestaAsync(string texto, bool correcta, int idPregunta)
        {
            // Obtiene el ultimo registro o null si no hay nada
            int id = await _context.Respuestas.CountAsync();
            // Si los registros no son 0
            if (id != 0)
            {
                // Se define el siguiente ID
                id += 1;
            }
            else
            {
                // Crea el primer ID
                id = 1;
            }
            // Crear un objeto con los atributos
            var newRespuesta = new Respuesta
            {
                IdRespuesta = id,
                Texto = texto,
                Correcta = correcta,
                IdPregunta = idPregunta
            };
            // Agregar el nuevo registro al contexto de base de datos
            _context.Respuestas.Add(newRespuesta);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devuelve el objeto creado creada
            return newRespuesta;
        }

        public async Task<Respuesta> UpdateRespuestaAsync(int id, string texto, bool correcta, int idPregunta)
        {
            // Busca el registro existente por ID
            Respuesta respuesta = await this.GetRespuestaAsync(id);
            // Si el objeto no es null
            if (respuesta != null)
            {
                // Actualiza los atributos segun los datos recibidos
                respuesta.Texto = texto;
                respuesta.Correcta = correcta;
                respuesta.IdPregunta = idPregunta;
                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            // Devuelve el objeto actualizado o null si no se encontro
            return respuesta;
        }

        public async Task<int> DeleteRespuestaAsync(int id)
        {
            // Busca el registro existente por ID
            Respuesta respuesta = await this.GetRespuestaAsync(id);
            // Inicializamos el resultado -1 
            int result = -1;
            // Si existe el registro lo elimina
            if (respuesta != null)
            {
                _context.Respuestas.Remove(respuesta);
                // Guarda los cambios en la base de datos y guadamos los registros afectados
                result = await _context.SaveChangesAsync();
            }
            // Devolvemos los registros afectados
            return result;
        }
        #endregion

    }
}
