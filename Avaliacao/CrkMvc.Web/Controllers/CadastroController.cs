using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crk.Aplicacao;
using Crk.Dominio;

namespace CrkMvc.Web.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            var listaCd =
                new CdAplicacao().Listar();
            ViewBag.Mensagem = null;
            int count = 0;
            foreach (Cd cd in listaCd)
                count++;
            if (count == 0) ViewBag.Mensagem = "Não possui cd lançados!";
            return View(listaCd);
        }

        public ActionResult Create()
        {

            var cd = new Cd();

            PopulateArtistaDropDownList();
            PopulateGeneroMusicalDropDownList();

            return View(cd);
        }

        [HttpPost]
        public ActionResult Create(Cd cd)
        {
            if (ModelState.IsValid)
            {
                var cdAplicacao = new CdAplicacao();

                try
                {
                    cd.artista = new ArtistaAplicacao().ListaArtista().Where(x => x.artista_id == cd.artista_id).ToList()[0].nome;
                    cd.generoMusical =  new GeneroMusicalAplicacao().ListaGeneroMusical().Where(x => x.generomusical_id == cd.generomusical_id).ToList()[0].descricao;
                    cdAplicacao.Salvar(cd);
                    return RedirectToAction("Cadastro", "Cd", new { id = cd.cd_id });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            if (cd.artista_id != null)
                PopulateArtistaDropDownList((int)cd.artista_id);

            if (cd.generomusical_id != null)
                PopulateGeneroMusicalDropDownList((int)cd.generomusical_id);
            return View(cd);
        }

        public ActionResult Delete(int id)
        {
            var deletaCd= new CdAplicacao();
            var deletaCdMusicas = new CdMusicasAplicacao();

            var listaCdMusicas = deletaCdMusicas.Listar().Where(x => x.cd_id == id).ToList();

            if (listaCdMusicas.Any())
            {
                try
                {
                    deletaCdMusicas.Excluir(id);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            try
            {
                deletaCd.Excluir(id);
                ViewBag.Msg = "Excluido com sucesso!";
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return RedirectToAction("Index", "Solicitacao");
        }


















        private void PopulateArtistaDropDownList(object selectedArtista = null)
        {
            var listaArtistas = new ArtistaAplicacao().Listar().OrderBy(x => x.nome);
            ViewBag.artista_id = new SelectList(listaArtistas, "artista_id", "nome", selectedArtista);
        }

        private void PopulateGeneroMusicalDropDownList(object selectedGeneroMusical = null)
        {
            var listaGeneroMusical = new GeneroMusicalAplicacao().Listar().OrderBy(x => x.descricao);
            ViewBag.generoMusical_id = new SelectList(listaGeneroMusical, "generoMusical_id", "descricao", selectedGeneroMusical);
        }


    }
}