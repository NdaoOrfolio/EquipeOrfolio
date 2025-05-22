
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EquipeOrfolio.Models;

namespace EquipeOrfolio.Controllers
{
    public class ConsultantController : Controller
    {
        private OrfolioBaseEntities db = new OrfolioBaseEntities();

        public ActionResult Index() => View(db.Consultant.ToList());

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                db.Consultant.Add(consultant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultant);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Consultant consultant = db.Consultant.Find(id);
            if (consultant == null) return HttpNotFound();
            return View(consultant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultant).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultant);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Consultant consultant = db.Consultant.Find(id);
            if (consultant == null) return HttpNotFound();
            return View(consultant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultant consultant = db.Consultant.Find(id);
            db.Consultant.Remove(consultant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
