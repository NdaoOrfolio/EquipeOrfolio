
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EquipeOrfolio.Models;
using OrfolioBase.Models;

namespace OrfolioBase.Controllers
{
    public class GestionHeuresController : Controller
    {
        private OrfolioBaseEntities db = new OrfolioBaseEntities();

        public ActionResult Index()
        {
            DateTime troisMois = DateTime.Now.AddMonths(-3);

            var collaborateurs = from u in db.AspNetUsers
                                 //join ur in db.AspNetUserRoles on u.Id equals ur.UserId
                                 //join r in db.AspNetRoles on ur.RoleId equals r.Id
                                 //where r.Name == "Collaborateur"
                                 select new HeureCollaborateurViewModel
                                 {
                                     NomComplet = u.NomComplet,
                                     Email = u.Email,
                                     HeuresCumulées = db.HeuresTravaillees
                                         .Where(h => h.UserId == u.Id && h.DateTravail >= troisMois)
                                         .Sum(h => (decimal?)h.NombreHeures) ?? 0
                                 };

            return View(collaborateurs.ToList());
        }
    }
}
