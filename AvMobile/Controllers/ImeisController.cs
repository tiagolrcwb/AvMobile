
using Modelo.Cadastros;
using Servicos.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AvMobile.Controllers
{
    public class ImeisController : Controller
    {
        //private EFContext context = new EFContext();
        private AparelhoServico aparelhoServico = new AparelhoServico();
        private ImeiServico imeiServico = new ImeiServico();

        private ActionResult GravarImei(Imei imei)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    imeiServico.GravarImei(imei);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(imei);
            }
        }

        private ActionResult ObterDetalhesImei(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imei imei = imeiServico.ObterImeiPorId((long)id);
            if (imei == null)
            {
                return HttpNotFound();
            }
            return View(imei);
        }


        /*######################## INDEX #############################*/
        public ActionResult Index() {
            var imei = imeiServico.ObterImeiClassificadasPorId();
            return View(imei);
        }



        /*######################## INSERIR #############################*/
        public ActionResult Create() {
            ViewBag.aparelhoId = new SelectList(aparelhoServico.ObterAparelhosClassificadosPorNome(), "id", "modelo");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Imei imei) {
            GravarImei(imei);
            return View("index");
        }


        /*######################## EDITAR #############################*/
        public ActionResult Edit(long id){
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imei imei = imeiServico.ObterImeiPorId(id);
            if (imei == null) {
                return HttpNotFound();
            }
            ViewBag.aparelhoId = new SelectList(aparelhoServico.ObterAparelhosClassificadosPorNome(), "id", "modelo", imei.aparelhoId);
            return View(imei);
        }
        [HttpPost]
        public ActionResult Edit(Imei imei)
        {
            GravarImei(imei);
            return View(imei);
            
        }


        /*######################## DELETE #############################*/
       /* public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imei imei = context.Tbl_Imei.Find(id);
            if (imei == null)
            {
                return HttpNotFound();
            }
            return View(imei);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Imei imei = context.Tbl_Imei.Find(id);
            context.Tbl_Imei.Remove(imei);
            context.SaveChanges();
            return RedirectToAction("Index");
        }*/


        /*######################## DETALHES #############################*/
        public ActionResult Details(long id) {
            ObterDetalhesImei(id);
            return View("index");
        }



    }
}