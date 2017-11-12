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
using System.Web.UI.WebControls;

namespace AvMobile.Controllers
{
    public class AvaliacaoController : Controller
    {
        public enum AceiteEnum { NÃO, SIM};
        //Avaliação da Tela
        private static int p1_op1 = 0;  //Sem riscos
        private static int p1_op2 = 10; //Riscada
        private static int p1_op3 = 40; //Trincada
        private static int p1_op4 = 100; //Quebrada

        //Avaliação da Tela
        private static int p2_op1 = 0; //Sem Riscos
        private static int p2_op2 = 5; //Riscada
        private static int p2_op3 = 15; //Trincada
        private static int p2_op4 = 25; //Quebrada

        //Avaliação Bateria
        private static int p3_op1 = 0; //Nova
        private static int p3_op2 = 25; //Duração Baixa
        private static int p3_op3 = 50; //Danificada

        //Avaliação Botões
        private static int p4_op1 = 0; //Integros
        private static int p4_op2 = 100;//Quebrados

        //Avaliação do Carregador
        private static int p5_op1 = 0; //Funcionando
        private static int p5_op2 = 10; //Defeito


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
        public JsonResult ObterAparelho(int id)
        {
            Aparelho aparelho = context.Tbl_Aparelho.Find(id);
            return Json(aparelho, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult RetornaDesconto(string p, int op, int id)
        {
            Aparelho aparelho = context.Tbl_Aparelho.Find(id);

            if (p == "p1")
            {
                if (op == 1)
                {
                    return Json((aparelho.valor * p1_op1)/100, JsonRequestBehavior.AllowGet);
                }
                if (op == 2)
                {
                    return Json((aparelho.valor * p1_op2) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 3)
                {
                    return Json((aparelho.valor * p1_op3) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 4)
                {
                    return Json((aparelho.valor * p1_op4) / 100, JsonRequestBehavior.AllowGet);
                }
            }
            if (p == "p2")
            {
                if (op == 1)
                {
                    return Json((aparelho.valor * p2_op1) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 2)
                {
                    return Json((aparelho.valor * p2_op2) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 3)
                {
                    return Json((aparelho.valor * p2_op3) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 4)
                {
                    return Json((aparelho.valor * p2_op4) / 100, JsonRequestBehavior.AllowGet);
                }
            }
            if (p == "p3")
            {
                if (op == 1)
                {
                    return Json((aparelho.valor * p3_op1) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 2)
                {
                    return Json((aparelho.valor * p3_op2) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 3)
                {
                    return Json((aparelho.valor * p3_op3) / 100, JsonRequestBehavior.AllowGet);
                }
            }
            if (p == "p4")
            {
                if (op == 1)
                {
                    return Json((aparelho.valor * p4_op1) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 2)
                {
                    return Json((aparelho.valor * p4_op2) / 100, JsonRequestBehavior.AllowGet);
                }
              
            }
            if (p == "p5")
            {
                if (op == 1)
                {
                    return Json((aparelho.valor * p5_op1) / 100, JsonRequestBehavior.AllowGet);
                }
                if (op == 2)
                {
                    return Json((aparelho.valor * p5_op2) / 100, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        /*######################## ACEITAS #############################*/
        public ActionResult Aceitas()
        {
            var avaliacoes = context.Tbl_Avaliacao.Include(a => a.usuario).Include(f => f.filial).Include(i => i.imei).Where(a =>a.aceite==1);
            return View(avaliacoes);
        }


        /*######################## ACEITE #############################*/
        public ActionResult Aceite(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = context.Tbl_Avaliacao.Find(id);
            ViewBag.UsuarioId = 1;
            ViewBag.FilialId = 1;
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aceite(Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                context.Entry(avaliacao).State = EntityState.Modified;
                context.SaveChanges(); return RedirectToAction("Index");
            }
            return View(avaliacao);
        }


        /*######################## DETALHES #############################*/
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Avaliacao avaliacao = context.Tbl_Avaliacao.Where(a => a.id == id).Include(f => f.filial).Include(i => i.imei).Include(u =>u.usuario).First();

            Aparelho aparelho = context.Tbl_Aparelho.Find(avaliacao.imei.aparelhoId);
            ViewBag.Aparelho = aparelho.modelo;
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        /*######################## DELETE #############################*/
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = context.Tbl_Avaliacao.Where(a => a.id == id).Include(f => f.filial).Include(i => i.imei).Include(u => u.usuario).First();

            Aparelho aparelho = context.Tbl_Aparelho.Find(avaliacao.imei.aparelhoId);
            ViewBag.Aparelho = aparelho.modelo;


            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Avaliacao avaliacao = context.Tbl_Avaliacao.Find(id);
            context.Tbl_Avaliacao.Remove(avaliacao);
            context.SaveChanges();
            return RedirectToAction("Index");
        }








    }
}