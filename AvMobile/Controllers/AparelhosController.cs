﻿using AvMobile.Contexts;
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
    public class AparelhosController : Controller
    {
        private EFContext context = new EFContext();
        

        /*######################## INDEX #############################*/
        public ActionResult Index()
        {
            return View(context.Tbl_Aparelho.OrderBy(m=>m.modelo));
        }


        /*######################## INSERIR #############################*/
        public ActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aparelho aparelho){
            context.Tbl_Aparelho.Add(aparelho);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        /*######################## EDITAR #############################*/
        public ActionResult Edit(long? id){
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho= context.Tbl_Aparelho.Find(id);
            if (aparelho == null){
                return HttpNotFound();
            }
            return View(aparelho);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aparelho aparelho)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aparelho).State = EntityState.Modified;
                context.SaveChanges(); return RedirectToAction("Index");
            }
            return View(aparelho);
        }

        /*######################## DETALHES #############################*/
        public ActionResult Details(long? id){
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho= context.Tbl_Aparelho.Find(id);
            if (aparelho == null) {
                return HttpNotFound();
            }
            return View(aparelho);
        }

        /*######################## DELETE #############################*/
        public ActionResult Delete(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = context.Tbl_Aparelho.Find(id);
            if (aparelho == null) {
                return HttpNotFound();
            }
            return View(aparelho);
        }
        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Delete(long id) {
            Aparelho aparelho = context.Tbl_Aparelho.Find(id);
            context.Tbl_Aparelho.Remove(aparelho);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}