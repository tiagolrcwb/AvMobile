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
    public class UsuariosController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = context.Tbl_Usuario.Include(u => u.filial).Include(f => f.filial);
            return View(usuarios);
            //return View(context.Tbl_Usuario.OrderBy(u => u.id));
        }

        /*######################## INSERIR #############################*/
        public ActionResult Create()
        {
            ViewBag.filialId = new SelectList(context.Tbl_Filial.OrderBy(f => f.nome), "id", "nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            context.Tbl_Usuario.Add(usuario);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}