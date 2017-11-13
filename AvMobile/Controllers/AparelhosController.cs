using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using Servicos.Cadastros;

namespace AvMobile.Controllers
{
    public class AparelhosController : Controller
    {
        //private EFContext context = new EFContext();
        private AparelhoServico aparelhoServico = new AparelhoServico();

        private ActionResult GravarAparelho(Aparelho aparelho)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aparelhoServico.GravarAparelho(aparelho);
                    return RedirectToAction("Lista");
                }
                return View(aparelho);
            }
            catch
            {
                return View(aparelho);
            }
        }

        private ActionResult ObterDetalhesAparelho(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId((long)id);
            if (aparelho == null)
            {
                return HttpNotFound();
            }
            return View(aparelho);
        }
        

        /*######################## INDEX #############################*/
        public ActionResult Index()
        {
            return View();
        }


        /*######################## LISTA #############################*/
        public ActionResult Lista()
        {
            return View(aparelhoServico.ObterAparelhosClassificadosPorNome());
        }

        /*######################## INSERIR #############################*/
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
       

        public ActionResult Create(Aparelho aparelho){
            return GravarAparelho(aparelho);
        }

        /*######################## EDITAR #############################*/
        public ActionResult Edit(int id){
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = aparelhoServico.ObterAparelhoPorId(id);
            if (aparelho == null){
                return HttpNotFound();
            }
            return View(aparelho);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aparelho aparelho)
        {
            return GravarAparelho(aparelho);
        }

        /*######################## DETALHES #############################*/
        public ActionResult Details(long? id){
            return ObterDetalhesAparelho(id);
        }

       


        



    }
}