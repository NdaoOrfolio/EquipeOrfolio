
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EquipeOrfolio.Models;

namespace EquipeOrfolio.Controllers
{
    public class CandidatController : Controller
    {
        private OrfolioBaseEntities db = new OrfolioBaseEntities();

        public ActionResult Index() => View(db.Candidat.ToList());

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Candidat candidat = db.Candidat.Find(id);
            if (candidat == null) return HttpNotFound();
            return View(candidat);
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                db.Candidat.Add(candidat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidat);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Candidat candidat = db.Candidat.Find(id);
            if (candidat == null) return HttpNotFound();
            return View(candidat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidat);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Candidat candidat = db.Candidat.Find(id);
            if (candidat == null) return HttpNotFound();
            return View(candidat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidat candidat = db.Candidat.Find(id);
            db.Candidat.Remove(candidat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
