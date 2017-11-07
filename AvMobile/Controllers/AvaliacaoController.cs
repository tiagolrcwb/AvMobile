using AvMobile.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.ManagedDataAccess;
using System.Web;
using System.Web.Mvc;
using AvMobile.Models;
using System.Net;
using System.Data.Entity;

namespace AvMobile.Controllers
{
    public class AvaliacaoController : Controller
    {
        private EFContext context = new EFContext();
        /*######################## INDEX #############################*/
        public ActionResult Index()
        {
            var avaliacoes = context.Tbl_Avaliacao.Include(a => a.usuario).Include(f => f.filial).Include(i => i.imei);
            return View(avaliacoes);
        }
        /*######################## INSERIR #############################*/
        public ActionResult Create()
        {
            ViewBag.UsuarioId = 1;
            ViewBag.FilialId = 1;
            ViewBag.imeiId = new SelectList(context.Tbl_Imei.OrderBy(i => i.num_imei), "id", "num_imei");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Avaliacao avaliacao)
        {
            context.Tbl_Avaliacao.Add(avaliacao);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}