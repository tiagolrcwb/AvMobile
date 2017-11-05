using AvMobile.Contexts;
using AvMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvMobile.Controllers
{
    public class FiliaisController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Filiais
        public ActionResult Index()
        {
            return View(context.Tbl_Filial.OrderBy(f => f.nome));
        }

        public ActionResult Create()
        {
            ViewBag.cidadeId = new SelectList(context.TblCidade.OrderBy(c => c.nome), "id", "nome");
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
    }
}