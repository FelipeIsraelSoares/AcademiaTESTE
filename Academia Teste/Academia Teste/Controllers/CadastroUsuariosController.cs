using Academia_Teste.Filters;
using Academia_Teste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academia_Teste.Controllers
{
    public class CadastroUsuariosController : Controller
    {
        //
        // GET: /CadastroUsuarios/
        //[Authorize(Roles="Administrador")]
        [AutorizacaoTipo(new []{TipoUsuario.Administrador})]
        public ActionResult Index()
        {
            return View();
        }
	}
}