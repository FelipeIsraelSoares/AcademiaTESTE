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
    public class PlanExecController : Controller
    {
        private PlanoExeContext db = new PlanoExeContext();

        // GET: /PlanExec/
        public ActionResult Index()
        {
            return View(db.Modalidade.ToList());
        }

        // GET: /PlanExec/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoExe planoexe = db.Modalidade.Find(id);
            if (planoexe == null)
            {
                return HttpNotFound();
            }
            return View(planoexe);
        }

        // GET: /PlanExec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PlanExec/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,IdCliente,IdProfessor,IdModalidade")] PlanoExe planoexe)
        {
            if (ModelState.IsValid)
            {
                db.Modalidade.Add(planoexe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planoexe);
        }

        // GET: /PlanExec/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoExe planoexe = db.Modalidade.Find(id);
            if (planoexe == null)
            {
                return HttpNotFound();
            }
            return View(planoexe);
        }

        // POST: /PlanExec/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,IdCliente,IdProfessor,IdModalidade")] PlanoExe planoexe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planoexe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planoexe);
        }

        // GET: /PlanExec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoExe planoexe = db.Modalidade.Find(id);
            if (planoexe == null)
            {
                return HttpNotFound();
            }
            return View(planoexe);
        }

        // POST: /PlanExec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanoExe planoexe = db.Modalidade.Find(id);
            db.Modalidade.Remove(planoexe);
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
