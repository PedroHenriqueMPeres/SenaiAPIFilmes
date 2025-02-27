using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;

namespace api_filmes_senai.Repository
{   /// <summary>
    /// Classe que vai implementar a IGeneroRepository
    /// Ou seja vamos implementar os métodos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        private readonly Filmes_Context _context;
        public GeneroRepository(Filmes_Context contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Guid id, Genero genero)
        {
            try
            {
                Genero generoBuscado = _context.Generos.Find(id)!;

                if (generoBuscado != null)
                {
                    generoBuscado.Nome = genero.Nome;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Genero BuscarPorId(Guid id)
        { try
            {
                Genero generoBuscado = _context.Generos.Find(id)!;
                return generoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                _context.Generos.Add(novoGenero);
                _context.SaveChanges();
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
                Genero generoBuscado = _context.Generos.Find(id)!;
                if (generoBuscado != null)
                {
                    _context.Generos.Remove(generoBuscado);

                }

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            }

        public List<Genero> Listar()
        {
            try
            {
               List<Genero> listaGeneros = _context.Generos.ToList();

               return listaGeneros;
            }
            catch(Exception) 
            { 
                throw;
            }
            
            
        }
    }
}
