
using Modelo.Cadastros;
using Modelo.Tabelas;
using Servicos.Cadastros;
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
        private UsuarioServico usuarioServico= new UsuarioServico();
        private FilialServico filialServico = new FilialServico();

        private ActionResult GravarUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioServico.GravarUsuario(usuario);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        private ActionResult ObterDetalhesUsuario(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioServico.ObterUsuarioPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = usuarioServico.ObterUsuariosClassificadasPorId();
            return View(usuarios);
        }

        /*######################## INSERIR #############################*/
        public ActionResult Create()
        {
            ViewBag.filialId = new SelectList(filialServico.ObterFiliaisClassificadasPorId(), "id", "nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            return GravarUsuario(usuario);
        }
    }
}