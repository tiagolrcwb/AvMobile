using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using Servicos.Cadastros;
using System;

namespace AvMobile.Controllers
{
    public class AparelhosController : Controller
    {

        private AparelhoServico aparelhoServico = new AparelhoServico();

        //Metodo que verifica se existe um usuario logado e retorna a view solicitada na actionresult
        public ActionResult Renderiza(Object view)
        {
            if (Session["usuarioId"] == null)
            {
                return RedirectToAction("Logar", "Login");
            }
            return View(view);
        }
        //Sobrecarga do metodo em caso de View vazia.
        public ActionResult Renderiza()
        {
            if (Session["usuarioId"] == null)
            {
                return RedirectToAction("Logar", "Login");
            }
            return View();
        }

        private ActionResult GravarAparelho(Aparelho aparelho)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aparelhoServico.GravarAparelho(aparelho);
                    return RedirectToAction("Lista");
                }
                return View(aparelho);
            }
            catch
            {
                return View(aparelho);
            }
        }

        private ActionResult ObterDetalhesAparelho(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId((long)id);
            if (aparelho == null)
            {
                return HttpNotFound();
            }
            return View(aparelho);
        }
        

        /*######################## INDEX #############################*/
        public ActionResult Index()
        {
            return Renderiza();
        }


        /*######################## LISTA #############################*/
        public ActionResult Lista()
        {
            return Renderiza(aparelhoServico.ObterAparelhosClassificadosPorNome());
        }

        /*######################## INSERIR #############################*/
        public ActionResult Create(){
            return Renderiza();
        }

        [HttpPost]
        public ActionResult Create(Aparelho aparelho){
            return GravarAparelho(aparelho);
        }

        /*######################## EDITAR #############################*/
        public ActionResult Edit(int id){
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId(id);
            if (aparelho == null){
                return Renderiza(HttpNotFound());
            }
            return Renderiza(aparelho);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aparelho aparelho)
        {
            return GravarAparelho(aparelho);
        }

        /*######################## DETALHES #############################*/
        public ActionResult Details(long? id){
            return Renderiza(ObterDetalhesAparelho(id));
        }

       


        



    }
}