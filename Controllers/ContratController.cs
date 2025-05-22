
using System.Linq;
using System.Web.Mvc;
using EquipeOrfolio.Models;

namespace EquipeOrfolio.Controllers
{
    public class ContratController : Controller
    {
        private OrfolioBaseEntities db = new OrfolioBaseEntities();

        public ActionResult Generer(int id)
        {
            var candidat = db.Candidat.Find(id);
            if (candidat == null) return HttpNotFound();
            ViewBag.TypeContrat = candidat.TypePoste == "Consultant" ? "Contrat de prestation" : "Convention de stage";
            return View(candidat);
        }
    }
}
