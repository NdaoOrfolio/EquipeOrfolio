
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EquipeOrfolio.Models;

namespace EquipeOrfolio.Controllers
{
    public class StageController : Controller
    {
        private OrfolioBaseEntities db = new OrfolioBaseEntities();

        public ActionResult Index() => View(db.Stage.ToList());

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stage stage)
        {
            if (ModelState.IsValid)
            {
                db.Stage.Add(stage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stage);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Stage stage = db.Stage.Find(id);
            if (stage == null) return HttpNotFound();
            return View(stage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Stage stage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stage).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stage);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Stage stage = db.Stage.Find(id);
            if (stage == null) return HttpNotFound();
            return View(stage);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stage stage = db.Stage.Find(id);
            db.Stage.Remove(stage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
