using AvMobile.Contexts;
using Modelo.Cadastros;
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
        private EFContext context = new EFContext();


        /*######################## INDEX #############################*/
        public ActionResult Index() {
            var imei = context.Tbl_Imei.Include(i => i.aparelho).Include(a => a.aparelho).OrderBy(n => n.id);
            return View(imei);
        }



        /*######################## INSERIR #############################*/
        public ActionResult Create() {
            ViewBag.aparelhoId = new SelectList(context.Tbl_Aparelho.OrderBy(b => b.modelo), "id", "modelo");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Imei imei) {
            try {
                context.Tbl_Imei.Add(imei);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(imei);
            }
        }


        /*######################## EDITAR #############################*/
        public ActionResult Edit(long? id){
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imei imei = context.Tbl_Imei.Find(id);
            if (imei == null) {
                return HttpNotFound();
            }
            ViewBag.aparelhoId = new SelectList(context.Tbl_Aparelho.OrderBy(a => a.modelo), "id", "modelo", imei.aparelhoId);
            return View(imei);
        }
        [HttpPost]
        public ActionResult Edit(Imei imei)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(imei).State = EntityState.Modified; context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(imei);
            }
            catch {
                return View(imei);
            }
        }


        /*######################## DELETE #############################*/
        public ActionResult Delete(long? id)
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
        }


        /*######################## DETALHES #############################*/
        public ActionResult Details(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imei imei = context.Tbl_Imei.Where(i => i.id== id).Include(a => a.aparelho).First();
            if (imei == null) {
                return HttpNotFound();
            } return View(imei);
        }



    }
}