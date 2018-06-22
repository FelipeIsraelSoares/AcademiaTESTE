using Academia_Teste.Filters;
using Academia_Teste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academia_Teste.Controllers
{
    public class AdministrarUsuarioController : Controller
    {
        private UsuarioContext db = new UsuarioContext();



        [AutorizacaoTipo(new[] { TipoUsuario.Administrador })]
        public ActionResult Index()
        {
            var usuario = db.Usuarios.ToArray();

            return View(usuario);
        }

        [AutorizacaoTipo(new[] { TipoUsuario.Administrador })]
        public ActionResult Edit(int id)
        {
            Usuario editUser = new Usuario();

            editUser = db.Usuarios.Find(id);

            return View(editUser);
        }


        [HttpPost]
        [AutorizacaoTipo(new[] { TipoUsuario.Administrador })]
        public ActionResult Edit(Academia_Teste.Models.Usuario userEdit)
        {
            db.Entry(userEdit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [AutorizacaoTipo(new[] { TipoUsuario.Administrador })]
        public ActionResult Delete(int id)
        {
            Usuario deletetUser = new Usuario();

            deletetUser = db.Usuarios.Find(id);
            db.Usuarios.Remove(deletetUser);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}