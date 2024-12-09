using AsfaAPI.Models;

namespace AsfaAPI.Repositories
{
    public interface IRepositoryAsfa
    {
        public Task<List<Pregunta>> GetPreguntas();
        public Task<Pregunta> GetPregunta(int id);
        public Task DeletePregunta(int id);
        public Task<Pregunta> UpdatePregunta(int id);
    }
}
