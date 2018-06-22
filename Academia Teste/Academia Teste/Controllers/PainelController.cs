using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academia_Teste.Controllers
{
    public class PainelController : Controller
    {
        //
        // GET: /Painel/
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Padrao"))
            {
                ViewBag.Message = "Você é um usuário padrão e não poderá alterar dados no sistema";
            }
            return View();
        }

        [Authorize]
        public ActionResult Mensagens()
        {
            return View();
        }
	}
}