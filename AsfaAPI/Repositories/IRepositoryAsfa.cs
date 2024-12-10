using AsfaAPI.Models;

namespace AsfaAPI.Repositories
{
    public interface IRepositoryAsfa
    {
        // Metodos para Rol
        Task<List<Rol>> GetRolesAsync();
        Task<Rol> GetRolByIdAsync(int id);
        Task<Rol> CreateRolAsync(string nombre, string? descripcion);
        Task<Rol> UpdateRolAsync(int id, string nombre, string? descripcion);
        Task<int>  DeleteRolAsync(int id);

        // Metodos para Usuario
        Task<List<Usuario>> GetUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> CreateUsuarioAsync(string nombre, string dni, byte[] password, string salt, string? token, DateTime fechaRegistro, int idRol);
        Task<Usuario> UpdateUsuarioAsync(int id, string nombre, string dni, byte[] password, string salt, string? token, DateTime fechaRegistro, int idRol);
        Task<int> DeleteUsuarioAsync(int id);

        // Metodos para Apunte
        Task<List<Apunte>> GetApuntesAsync();
        Task<Apunte> GetApunteByIdAsync(int id);
        Task<Apunte> CreateApunteAsync(string texto);
        Task<Apunte> UpdateApunteAsync(int id, string texto);
        Task<int> DeleteApunteAsync(int id);

        // Metodos para PreguntaCategoria
        Task<List<PreguntaCategoria>> GetCategoriasPreguntasAsync();
        Task<PreguntaCategoria> GetPreguntaCategoriaByIdAsync(int id);
        Task<PreguntaCategoria> CreatePreguntaCategoriaAsync(string nombre, string? descripcion);
        Task<PreguntaCategoria> UpdatePreguntaCategoriaAsync(int id, string nombre, string? descripcion);
        Task<int> DeletePreguntaCategoriaAsync(int id);

        // Metodos para Dificultad
        Task<List<Dificultad>> GetDificultadesAsync();
        Task<Dificultad> GetDificultadByIdAsync(int id);
        Task<Dificultad> CreateDificultadAsync(Dificultad dificultad);
        Task<Dificultad> UpdateDificultadAsync(int id, Dificultad dificultad);
        Task<int> DeleteDificultadAsync(int id);

        // Metodos para Duda
        Task<List<Duda>> GetDudasAsync();
        Task<Duda> GetDudaByIdAsync(int id);
        Task<Duda> CreateDudaAsync(Duda duda);
        Task<Duda> UpdateDudaAsync(int id, Duda duda);
        Task<int> DeleteDudaAsync(int id);

        // Metodos para Examen
        Task<List<Examen>> GetExamenesAsync();
        Task<Examen> GetExamenByIdAsync(int id);
        Task<Examen> CreateExamenAsync(Examen examen);
        Task<Examen> UpdateExamenAsync(int id, Examen examen);
        Task<int> DeleteExamenAsync(int id);

        // Metodos para Fallo
        Task<List<Fallo>> GetFallosAsync();
        Task<Fallo> GetFalloByIdAsync(int id);
        Task<Fallo> CreateFalloAsync(Fallo fallo);
        Task<Fallo> UpdateFalloAsync(int id, Fallo fallo);
        Task<int> DeleteFalloAsync(int id);

        // Metodos para Pregunta
        Task<List<Pregunta>> GetPreguntasAsync();
        Task<Pregunta> GetPreguntaByIdAsync(int id);
        Task<Pregunta> CreatePreguntaAsync(string texto, string? urlImg, DateTime fechaCreacion, int idPreguntaCategoria, int idDificultad, int? idApunte);
        Task<Pregunta> UpdatePreguntaAsync(int id, string texto, string? urlImg, DateTime fechaCreacion, int idPreguntaCategoria, int idDificultad, int? idApunte);
        Task<int> DeletePreguntaAsync(int id);

        // Metodos para Resolucion
        Task<List<Resolucion>> GetResolucionesAsync();
        Task<Resolucion> GetResolucionByIdAsync(int id);
        Task<Resolucion> CreateResolucionAsync(Resolucion resolucion);
        Task<Resolucion> UpdateResolucionAsync(int id, Resolucion resolucion);
        Task<int> DeleteResolucionAsync(int id);

        // Metodos para Respuesta
        Task<List<Respuesta>> GetRespuestasAsync();
        Task<Respuesta> GetRespuestaByIdAsync(int id);
        Task<Respuesta> CreateRespuestaAsync(Respuesta respuesta);
        Task<Respuesta> UpdateRespuestaAsync(int id, Respuesta respuesta);
        Task<int> DeleteRespuestaAsync(int id);
    }

}
