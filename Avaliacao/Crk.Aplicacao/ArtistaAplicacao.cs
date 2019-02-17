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
    public class ArtistaAplicacao
    {

        public static DatabaseContext context { get; set; }

        public ArtistaAplicacao()
        {
            context = new DatabaseContext();
        }

        public void Salvar( Artista artista)
        {
            context.Artistas.Add(artista);
            context.SaveChanges();
        }

        public IEnumerable<Artista> Listar()
        {
            return context.Artistas.ToList();
        }

        public List<Artista> ListaArtista()
        {
            return context.Artistas.ToList();
        }

        public void Alterar(Artista artista)
        {
            Artista artistaSalvar = context.Artistas.First(x => x.artista_id == artista.artista_id);

            artistaSalvar.nome = artista.nome;

            context.SaveChanges();

        }

        public void Excluir(int id)
        {
            Artista artistaExcluir = context.Artistas.First(x => x.artista_id == id);
            context.Set<Artista>().Remove(artistaExcluir);
            context.SaveChanges();
        }
    }
}
