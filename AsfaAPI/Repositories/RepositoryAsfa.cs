using AsfaAPI.Data;
using AsfaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AsfaAPI.Repositories
{
    public class RepositoryAsfa : IRepositoryAsfa
    {
        private AsfaContext _context;

        public RepositoryAsfa(AsfaContext context)
        {
            _context = context;
        }

        public async Task<List<Pregunta>> GetPreguntas()
        {
            List<Pregunta> preguntas = await _context.Preguntas.ToListAsync();
            return preguntas;
        }

        public async Task<Pregunta> GetPregunta(int id)
        {
            Pregunta pregunta = await _context.Preguntas.FirstOrDefaultAsync(o => o.IdPregunta == id);
            return pregunta;
        }
    }
}
