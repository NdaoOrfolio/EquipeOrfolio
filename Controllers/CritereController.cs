
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EquipeOrfolio.Models;

namespace EquipeOrfolio.Controllers
{
    public class CritereController : Controller
    {
        private OrfolioBaseEntities db = new OrfolioBaseEntities();

        public ActionResult Index() => View(db.Critere.ToList());

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description")] Critere critere)
        {
            if (ModelState.IsValid)
            {
                db.Critere.Add(critere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(critere);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Critere critere = db.Critere.Find(id);
            if (critere == null) return HttpNotFound();
            return View(critere);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CritereID,Description")] Critere critere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(critere).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(critere);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Critere critere = db.Critere.Find(id);
            if (critere == null) return HttpNotFound();
            return View(critere);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Critere critere = db.Critere.Find(id);
            db.Critere.Remove(critere);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
