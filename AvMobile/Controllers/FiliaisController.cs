using AvMobile.Contexts;
using Modelo.Cadastros;
using Modelo.Tabelas;
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
        private EFContext context = new EFContext();


        /*######################## INDEX #############################*/
        public ActionResult Index(){

            var filiais = context.Tbl_Filial.Include(f => f.cidade).Include(c => c.cidade);
            return View(filiais);
        }

        public ActionResult Create()
        {
            ViewBag.cidadeId = new SelectList(context.Tbl_Cidade.OrderBy(c => c.nome), "id", "nome");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Filial filial)
        {
            try
            {
                context.Tbl_Filial.Add(filial);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(filial);
            }
        }

        /*######################## EDITAR #############################*/
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = context.Tbl_Filial.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            ViewBag.cidadeId = new SelectList(context.Tbl_Cidade.OrderBy(c => c.nome), "id", "nome", filial.cidadeId);
            return View(filial);
        }
        [HttpPost]
        public ActionResult Edit(Filial filial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(filial).State = EntityState.Modified; context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(filial);
            }
            catch
            {
                return View(filial);
            }
        }

    }
}