using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;

namespace api_filmes_senai.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filmes_Context _context;

        public FilmeRepository(Filmes_Context context) {
            _context = context;
        }
        public void Atualizar(Guid id, Filme filme)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id)!;

                if (filmeBuscado != null)
                {
                    filmeBuscado.IdGenero = filme.IdGenero;
                    filmeBuscado.Titulo = filme.Titulo;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id)!;
                return filmeBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id)!;
                if (filmeBuscado != null)
                {
                    _context.Filmes.Remove(filmeBuscado);

                }

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filmes.ToList();
                return listaDeFilmes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                _context.Filmes.Add(novoFilme);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Filme(Filme novoFilme)
        {
            throw new NotImplementedException();
        }

        public List<Filme> ListarPorGenero(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
