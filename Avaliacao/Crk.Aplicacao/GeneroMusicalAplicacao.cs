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
    public class GeneroMusicalAplicacao
    {

        public static DatabaseContext context { get; set; }

        public GeneroMusicalAplicacao()
        {
            context = new DatabaseContext();
        }

        public void Salvar(GeneroMusical generoMusical)
        {
            context.GeneroMusicais.Add(generoMusical);
            context.SaveChanges();
        }

        public IEnumerable<GeneroMusical> Listar()
        {
            return context.GeneroMusicais.ToList();
        }

        public List<GeneroMusical> ListaGeneroMusical()
        {
            return context.GeneroMusicais.ToList();
        }

        public void Alterar(GeneroMusical generoMusical)
        {
            GeneroMusical generoMusicalSalvar = context.GeneroMusicais.First(x => x.generomusical_id == generoMusical.generomusical_id);

            generoMusicalSalvar.descricao = generoMusical.descricao;

            context.SaveChanges();

        }

        public void Excluir(int id)
        {
            GeneroMusical generoMusicalExcluir = context.GeneroMusicais.First(x => x.generomusical_id == id);
            context.Set<GeneroMusical>().Remove(generoMusicalExcluir);
            context.SaveChanges();
        }



    }
}
