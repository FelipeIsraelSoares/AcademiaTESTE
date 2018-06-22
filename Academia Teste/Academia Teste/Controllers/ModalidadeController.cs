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
    public class ModalidadeController : Controller
    {
        private ModalidadeContext db = new ModalidadeContext();

        // GET: /Modalidade/
        public ActionResult Index()
        {
            return View(db.Modalidade.ToList());
        }

        // GET: /Modalidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidade modalidade = db.Modalidade.Find(id);
            if (modalidade == null)
            {
                return HttpNotFound();
            }
            return View(modalidade);
        }

        // GET: /Modalidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Modalidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Valor")] Modalidade modalidade)
        {
            if (ModelState.IsValid)
            {
                db.Modalidade.Add(modalidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modalidade);
        }

        // GET: /Modalidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidade modalidade = db.Modalidade.Find(id);
            if (modalidade == null)
            {
                return HttpNotFound();
            }
            return View(modalidade);
        }

        // POST: /Modalidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Valor")] Modalidade modalidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modalidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modalidade);
        }

        // GET: /Modalidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidade modalidade = db.Modalidade.Find(id);
            if (modalidade == null)
            {
                return HttpNotFound();
            }
            return View(modalidade);
        }

        // POST: /Modalidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modalidade modalidade = db.Modalidade.Find(id);
            db.Modalidade.Remove(modalidade);
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
