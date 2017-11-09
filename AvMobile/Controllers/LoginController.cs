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
   

    public class LoginController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Login

        public ActionResult index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult index(Login login)
        {
            
            Usuario usuario = context.Tbl_Usuario.Find(login.login);
            if((String.Compare(usuario.senha, login.senha)==1))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
            
        }
    }
}