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
            return Renderiza(filiais);
        }

        public ActionResult Create()
        {
            ViewBag.cidadeId = new SelectList(cidadeServico.ObterCidadesClassificadasPorNome(), "id", "nome");
            return Renderiza();
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
                return Renderiza(HttpNotFound());
            }
            ViewBag.cidadeId = new SelectList(cidadeServico.ObterCidadesClassificadasPorNome(), "id", "nome", filial.cidadeId);
            return Renderiza(filial);
        }
        [HttpPost]
        public ActionResult Edit(Filial filial)
        {
            ViewBag.cidadeId = new SelectList(cidadeServico.ObterCidadesClassificadasPorNome(), "id", "nome", filial.cidadeId);
            return GravarFilial(filial);
        }

    }
}