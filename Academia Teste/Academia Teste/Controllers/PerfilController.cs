using Academia_Teste.Models;
using Academia_Teste.Utils;
using Academia_Teste.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Academia_Teste.Controllers
{
    public class PerfilController : Controller
    {
        
        private UsuarioContext db = new UsuarioContext();

        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var identity = User.Identity as ClaimsIdentity;
            //Login do usuário que está logado
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;

            var usuario = db.Usuarios.FirstOrDefault(u => u.Login == login);

              if (Hash.GerarHash(viewModel.SenhaAtual) != usuario.Senha)
                {
                    ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                    return View();
                }
            usuario.Senha = Hash.GerarHash(viewModel.NovaSenha);
            //AlterarSenha pela nova senha
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            TempData["SenhaAlterada"] = "Senha alterada com sucesso";
            return RedirectToAction("Index","Painel");
        }
	}
}