using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Academia_Teste.Models;

namespace Academia_Teste.Controllers
{
    public class PlanoExercicioController : Controller
    {
        private PlanoExercicioContext db = new PlanoExercicioContext();

        // GET: /PlanoExercicio/
        public ActionResult Index()
        {
            return View(db.PlanoExercicio.ToList());
        }

        // GET: /PlanoExercicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoExercicio planoexercicio = db.PlanoExercicio.Find(id);
            if (planoexercicio == null)
            {
                return HttpNotFound();
            }
            return View(planoexercicio);
        }

        // GET: /PlanoExercicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PlanoExercicio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,IdCliente,IdProfessor,IdModalidade")] PlanoExercicio planoexercicio)
        {
            if (ModelState.IsValid)
            {
                db.PlanoExercicio.Add(planoexercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planoexercicio);
        }

        // GET: /PlanoExercicio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoExercicio planoexercicio = db.PlanoExercicio.Find(id);
            if (planoexercicio == null)
            {
                return HttpNotFound();
            }
            return View(planoexercicio);
        }

        // POST: /PlanoExercicio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,IdCliente,IdProfessor,IdModalidade")] PlanoExercicio planoexercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planoexercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planoexercicio);
        }

        // GET: /PlanoExercicio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoExercicio planoexercicio = db.PlanoExercicio.Find(id);
            if (planoexercicio == null)
            {
                return HttpNotFound();
            }
            return View(planoexercicio);
        }

        // POST: /PlanoExercicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanoExercicio planoexercicio = db.PlanoExercicio.Find(id);
            db.PlanoExercicio.Remove(planoexercicio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
