﻿
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

        //Metodo que verifica se existe um usuario logado e retorna a view solicitada na actionresult
        public ActionResult Renderiza(Object view)
        {
            if (Session["usuarioId"] == null)
            {
                return RedirectToAction("Logar", "Login");
            }
            return View(view);
        }
        //Sobrecarga do metodo em caso de View vazia.
        public ActionResult Renderiza()
        {
            if (Session["usuarioId"] == null)
            {
                return RedirectToAction("Logar", "Login");
            }
            return View();
        }


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
            return Renderiza(usuarios);
        }

        /*######################## INSERIR #############################*/
        public ActionResult Create()
        {
            ViewBag.filialId = new SelectList(filialServico.ObterFiliaisClassificadasPorId(), "id", "nome");
            return Renderiza();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            return GravarUsuario(usuario);
        }
    }
}