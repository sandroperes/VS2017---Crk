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
    public class CdMusicasAplicacao
    {
        public static DatabaseContext context { get; set; }

        public CdMusicasAplicacao()
        {
            context = new DatabaseContext();
        }

        public void Salvar(CdMusicas cdMusicas)
        {
            context.CdMusicais.Add(cdMusicas);
            context.SaveChanges();
        }

        public IEnumerable<CdMusicas> Listar()
        {
            return context.CdMusicais.ToList();
        }

        public List<CdMusicas> ListaCdMusicas()
        {
            return context.CdMusicais.ToList();
        }

        public void Alterar(CdMusicas cdMusicas)
        {
            CdMusicas cdMusicasSalvar = context.CdMusicais.First(x => x.cdmusicas_id == cdMusicas.cdmusicas_id);

            cdMusicasSalvar.nomeMusica = cdMusicas.nomeMusica;
            cdMusicasSalvar.duracao = cdMusicas.duracao;

            context.SaveChanges();

        }

        public void Excluir(int id)
        {
            CdMusicas cdMusicasExcluir = context.CdMusicais.First(x => x.cdmusicas_id == id);
            context.Set<CdMusicas>().Remove(cdMusicasExcluir);
            context.SaveChanges();
        }



    }
}
