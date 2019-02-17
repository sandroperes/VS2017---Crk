using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Crk.Repositorio;
using Crk.Dominio;

namespace Crk.Aplicacao
{
    public class CdAplicacao
    {

        public static DatabaseContext context { get; set; }

        public CdAplicacao()
        {
            context = new DatabaseContext();
        }

        public void Salvar(Cd cd)
        {
            context.Cds.Add(cd);
            context.SaveChanges();
        }

        public IEnumerable<Cd> Listar()
        {
            return context.Cds.Include(x => x.Artista)
                              .Include(x => x.GeneroMusical)
                              .Include(f => f.CdMusicas)
                              .ToList();
        }

        public List<Cd> ListarCds()
        {
            return context.Cds.Include(x => x.Artista)
                              .Include(x => x.GeneroMusical)
                              .Include(f => f.CdMusicas)
                              .ToList();
        }

        public List<Cd> ListarCdsMusicas(int id)
        {
            return context.Cds.Include(x => x.Artista)
                              .Include(x => x.GeneroMusical)
                              .Include(f => f.CdMusicas)
                              .Where(x=>x.cd_id == id)
                              .ToList();
        }

        public List<Cd> ListarCdsTitulo( string titulo)
        {
            return context.Cds.Include(x => x.Artista)
                              .Include(x => x.GeneroMusical)
                              .Include(f => f.CdMusicas)
                              .Where(x=>x.titulo == titulo)
                              .ToList();
        }

        public List<Cd> ListarCdsArtista(string nome)
        {
            return context.Cds.Include(x => x.Artista)
                              .Include(x => x.GeneroMusical)
                              .Include(f => f.CdMusicas)                              
                              .Where(x=>x.Artista.nome == nome)
                              .ToList();
        }


        public List<Cd> ListarGeneroMusical(string generoMusical)
        {
            return context.Cds.Include(x => x.Artista)
                              .Include(x => x.GeneroMusical)
                              .Include(f => f.CdMusicas)
                              .Where(x => x.GeneroMusical.descricao == generoMusical)
                              .ToList();
        }

        public List<Cd> ListarNomeMusica(string nomeMusica)
        {
            return context.Cds.Include(x => x.Artista)
                              .Include(x => x.GeneroMusical)
                              .Include(f => f.CdMusicas.Select(y=>y.nomeMusica == nomeMusica))
                              .ToList();
        }



    }
}
