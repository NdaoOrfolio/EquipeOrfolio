
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using EquipeOrfolio.Models;

namespace EquipeOrfolio.Controllers
{
    public class AuthentificationController : Controller
    {
        private OrfolioBaseEntities db = new OrfolioBaseEntities();

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string NomUtilisateur, string MotDePasse)
        {
            var user = db.Utilisateur.FirstOrDefault(u => u.NomUtilisateur == NomUtilisateur && u.MotDePasse == MotDePasse);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.NomUtilisateur, false);
                Session["Role"] = user.Role;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Identifiants invalides";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
