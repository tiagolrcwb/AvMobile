using Modelo.Cadastros;
using Modelo.Tabelas;
using Servicos.Cadastros;
using Servicos.Tabelas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AvMobile.Controllers
{
    public class FiliaisController : Controller
    {
        private CidadeServico cidadeServico= new CidadeServico();
        private FilialServico filialServico = new FilialServico();



        private ActionResult GravarFilial(Filial filial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    filialServico.GravarFilial(filial);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(filial);
            }
        }

        private ActionResult ObterDetalhesFilial(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = filialServico.ObterFilialPorId((long)id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            return View(filial);
        }


        /*######################## INDEX #############################*/
        public ActionResult Index(){

            var filiais = filialServico.ObterFiliaisClassificadasPorId();
            return View(filiais);
        }

        public ActionResult Create()
        {
            ViewBag.cidadeId = new SelectList(cidadeServico.ObterCidadesClassificadasPorNome(), "id", "nome");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Filial filial)
        {
            GravarFilial(filial);
            return RedirectToAction("Index");
        }

        /*######################## EDITAR #############################*/
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = filialServico.ObterFilialPorId(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            ViewBag.cidadeId = new SelectList(cidadeServico.ObterCidadesClassificadasPorNome(), "id", "nome", filial.cidadeId);
            return View(filial);
        }
        [HttpPost]
        public ActionResult Edit(Filial filial)
        {
            ViewBag.cidadeId = new SelectList(cidadeServico.ObterCidadesClassificadasPorNome(), "id", "nome", filial.cidadeId);
            return GravarFilial(filial);
        }

    }
}