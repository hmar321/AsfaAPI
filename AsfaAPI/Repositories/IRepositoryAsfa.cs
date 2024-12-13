using AsfaAPI.Models;

namespace AsfaAPI.Repositories
{
    public interface IRepositoryAsfa
    {
        // Metodos para Rol
        Task<List<Rol>> GetRolesAsync();
        Task<Rol> GetRolAsync(int id);
        Task<Rol> CreateRolAsync(string nombre, string? descripcion);
        Task<Rol> UpdateRolAsync(int id, string nombre, string? descripcion);
        Task<int> DeleteRolAsync(int id);

        // Metodos para Usuario
        Task<List<Usuario>> GetUsuariosAsync();
        Task<Usuario> GetUsuarioAsync(int id);
        Task<Usuario> CreateUsuarioAsync(string nombre, string dni, byte[] password, string salt, string? token, DateTime fechaRegistro, int idRol);
        Task<Usuario> UpdateUsuarioAsync(int id, string nombre, string dni, byte[] password, string salt, string? token, int idRol);
        Task<int> DeleteUsuarioAsync(int id);

        // Metodos para Apunte
        Task<List<Apunte>> GetApuntesAsync();
        Task<Apunte> GetApunteAsync(int id);
        Task<Apunte> CreateApunteAsync(string texto);
        Task<Apunte> UpdateApunteAsync(int id, string texto);
        Task<int> DeleteApunteAsync(int id);

        // Metodos para PreguntaCategoria
        Task<List<PreguntaCategoria>> GetPreguntaCategoriasAsync();
        Task<PreguntaCategoria> GetPreguntaCategoriaAsync(int id);
        Task<PreguntaCategoria> CreatePreguntaCategoriaAsync(string nombre, string? descripcion);
        Task<PreguntaCategoria> UpdatePreguntaCategoriaAsync(int id, string nombre, string? descripcion);
        Task<int> DeletePreguntaCategoriaAsync(int id);

        // Metodos para Dificultad
        Task<List<Dificultad>> GetDificultadesAsync();
        Task<Dificultad> GetDificultadAsync(int id);
        Task<Dificultad> CreateDificultadAsync(string nombre, string? descripcion);
        Task<Dificultad> UpdateDificultadAsync(int id, string nombre, string? descripcion);
        Task<int> DeleteDificultadAsync(int id);

        // Metodos para Duda
        Task<List<Duda>> GetDudasAsync();
        Task<Duda> GetDudaAsync(int id);
        Task<Duda> CreateDudaAsync(string texto, DateTime fechaCreacion, int idUsuario, int idPregunta, int? idResolucion);
        Task<Duda> UpdateDudaAsync(int id, string texto, int idUsuario, int idPregunta, int? idResolucion);
        Task<int> DeleteDudaAsync(int id);

        // Metodos para Examen
        Task<List<Examen>> GetExamenesAsync();
        Task<Examen> GetExamenAsync(int id);
        Task<Examen> CreateExamenAsync(DateTime fecha, int fallos, int duracion, bool aprobado, int idUsuario);
        Task<Examen> UpdateExamenAsync(int id, int fallos, int duracion, bool aprobado, int idUsuario);
        Task<int> DeleteExamenAsync(int id);

        // Metodos para Fallo
        Task<List<Fallo>> GetFallosAsync();
        Task<Fallo> GetFalloAsync(int id);
        Task<Fallo> CreateFalloAsync(int idUsuario, int idPregunta);
        Task<Fallo> UpdateFalloAsync(int id, int idUsuario, int idPregunta);
        Task<int> DeleteFalloAsync(int id);

        // Metodos para Pregunta
        Task<List<Pregunta>> GetPreguntasAsync();
        Task<Pregunta> GetPreguntaAsync(int id);
        Task<Pregunta> CreatePreguntaAsync(string texto, string? urlImg, DateTime fechaCreacion, int idPreguntaCategoria, int idDificultad, int? idApunte);
        Task<Pregunta> UpdatePreguntaAsync(int id, string texto, string? urlImg, int idPreguntaCategoria, int idDificultad, int? idApunte);
        Task<int> DeletePreguntaAsync(int id);

        // Metodos para Resolucion
        Task<List<Resolucion>> GetResolucionesAsync();
        Task<Resolucion> GetResolucionAsync(int id);
        Task<Resolucion> CreateResolucionAsync(string texto, DateTime fechaCreacion, int idUsuario);
        Task<Resolucion> UpdateResolucionAsync(int id, string texto, int idUsuario);
        Task<int> DeleteResolucionAsync(int id);

        // Metodos para Respuesta
        Task<List<Respuesta>> GetRespuestasAsync();
        Task<Respuesta> GetRespuestaAsync(int id);
        Task<Respuesta> CreateRespuestaAsync(string texto, bool correcta, int idPregunta);
        Task<Respuesta> UpdateRespuestaAsync(int id, string texto, bool correcta, int idPregunta);
        Task<int> DeleteRespuestaAsync(int id);
    }

}
