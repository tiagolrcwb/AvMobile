
using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.ManagedDataAccess;
using System.Web;
using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using System.Data.Entity;
using Servicos.Cadastros;

namespace AvMobile.Controllers
{
    public class AparelhosController : Controller
    {
        //private EFContext context = new EFContext();
        private AparelhoServico aparelhoServico = new AparelhoServico();

        private ActionResult GravarAparelho(Aparelho aparelho)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aparelhoServico.GravarAparelho(aparelho);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Lista");
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
        

        /*######################## LISTA #############################*/
        public ActionResult Index()
        {
            return View();
        }


        /*######################## LISTA #############################*/
        public ActionResult Lista()
        {
            return View(aparelhoServico.ObterAparelhosClassificadosPorNome());
        }

        /*######################## INSERIR #############################*/
        public ActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aparelho aparelho){
            GravarAparelho(aparelho);
            return RedirectToAction("Lista");
        }

        /*######################## EDITAR #############################*/
        public ActionResult Edit(long id){
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId(id);
            if (aparelho == null){
                return HttpNotFound();
            }
            return View(aparelho);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aparelho aparelho)
        {
            return GravarAparelho(aparelho);
        }

        /*######################## DETALHES #############################*/
        public ActionResult Details(long? id){
            return ObterDetalhesAparelho(id);
        }

       


        



    }
}