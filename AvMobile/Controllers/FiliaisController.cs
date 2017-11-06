using AvMobile.Contexts;
using AvMobile.Models;
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
    }
}