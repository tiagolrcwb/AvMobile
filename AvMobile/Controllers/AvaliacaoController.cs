
using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.ManagedDataAccess;
using System.Web;
using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using System.Data.Entity;
using System.Web.UI.WebControls;
using Servicos.Cadastros;

namespace AvMobile.Controllers
{
    public class AvaliacaoController : Controller
    {
        private AvaliacaoServico avaliacaoServico = new AvaliacaoServico();
        private ImeiServico imeiServico = new ImeiServico();
        private AparelhoServico aparelhoServico = new AparelhoServico();


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

        private ActionResult GravarAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    avaliacaoServico.GravarAvaliacao(avaliacao);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(avaliacao);
            }
        }

        private ActionResult ObterDetalhesAvaliacao(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = avaliacaoServico.ObterAvaliacaoPorId((long)id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }




        /*######################## INDEX #############################*/
        public ActionResult Index()
        {
            return View(avaliacaoServico.ObterAvaliacoesClassificadasPorId());
        }
        /*######################## INSERIR #############################*/
        public ActionResult Create()
        {
            ViewBag.UsuarioId = 1;
            ViewBag.FilialId = 1;
            ViewBag.imeiId = new SelectList(imeiServico.ObterImeiClassificadasPorId(),"id", "num_imei");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Avaliacao avaliacao)
        {
            return GravarAvaliacao(avaliacao);
        }
        public JsonResult ObterAparelho(int id)
        {
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId(id);
            return Json(aparelho, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult RetornaDesconto(string p, int op, int id)
        {
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId(id);

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
            var avaliacoes = avaliacaoServico.ObterAvaliacoesAbertas();
            return View(avaliacoes);
        }


        /*######################## ACEITE #############################*/
        public ActionResult Aceite(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = avaliacaoServico.ObterAvaliacaoPorId(id);
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
            return GravarAvaliacao(avaliacao);
        }


        /*######################## DETALHES #############################*/
        public ActionResult Details(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Avaliacao avaliacao = avaliacaoServico.ObterAvaliacaoPorId(id);
            Imei imei = imeiServico.ObterImeiPorId(avaliacao.imeiId);
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId((int)imei.aparelhoId);

            ViewBag.Aparelho = aparelho.modelo;
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        /*######################## DELETE #############################*/
       /* public ActionResult Delete(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = avaliacaoServico.ObterAvaliacaoPorId(id);
            Imei imei = imeiServico.ObterImeiPorId(avaliacao.imeiId);
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId((int)imei.aparelhoId);
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
            Avaliacao avaliacao = avaliacaoServico.;
            context.Tbl_Avaliacao.Remove(avaliacao);
            context.SaveChanges();
            return RedirectToAction("Index");
        }*/








    }
}