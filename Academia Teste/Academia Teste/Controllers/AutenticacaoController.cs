using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Teste.Models;
using Academia_Teste.Utils;

using System.Web.Mvc;
using Academia_Teste.ViewModels;
using System.Security.Claims;

namespace Academia_Teste.Controllers
{
    public class AutenticacaoController : Controller
    {
        private UsuarioContext db = new UsuarioContext();
        //
        // GET: /Autenticacao/
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (db.Usuarios.Count(u => u.Login == viewModel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Esse login já está em uso");
                return View(viewModel);
            }
            Usuario usuario = new Usuario
            {
                Nome = viewModel.Nome,
                Login = viewModel.Login,
                Senha = Hash.GerarHash(viewModel.Senha)
            };




            db.Usuarios.Add(usuario);
            db.SaveChanges();


            TempData["Mensagem"] = "Cadastro Realizado com Sucesso";
            return RedirectToAction("Login");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {              
              UrlRetorno = ReturnUrl
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var usuario = db.Usuarios.FirstOrDefault(u => u.Login == viewModel.Login);
            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Login incorreto");
                return View(viewModel);
            }
            if (usuario.Senha != Hash.GerarHash(viewModel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewModel);
            }
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login),
                //Define o tipo de usuário no cookie
                new Claim(ClaimTypes.Role,usuario.Tipo.ToString())
            }, "ApplicationCookie");
            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewModel.UrlRetorno) || Url.IsLocalUrl(viewModel.UrlRetorno))
                return Redirect(viewModel.UrlRetorno);
            else
                return RedirectToAction("Index", "Painel");
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
	}
}