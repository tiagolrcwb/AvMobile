
using Modelo.Cadastros;
using Modelo.Tabelas;
using Servicos.Cadastros;
using System;
using System.Web.Mvc;

namespace AvMobile.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioServico usuarioServico = new UsuarioServico();

        private ActionResult FazerLogin(Usuario login)
        {
            if(login == null)
            {
                return HttpNotFound();
            }
            Usuario usuario = usuarioServico.ObterUsuarioPorLogin(login.login);
            if (usuario == null)
            {
                @ViewBag.erro = "Usuario ou Senha Incorreto.";
                return View();
            }
            if(usuario.senha.Equals(login.senha))
            {
                Session["usuarioId"] = usuario.id;
                Session["usuarioNome"] = usuario.login;
                Session["usuarioFilial"] = usuario.filialId;
                return RedirectToAction("Home", "Avaliacao");
            }
            else
            {
                @ViewBag.erro = "Usuario ou Senha Incorreto.";
                return View();
            }
        }
        public ActionResult Logar()
        {
            Session["usuarioId"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario usuario)
        {
            return FazerLogin(usuario);
        }
    }
}