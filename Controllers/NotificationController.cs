
using System.Net.Mail;
using System.Web.Mvc;
using EquipeOrfolio.Models;

namespace EquipeOrfolio.Controllers
{
    public class NotificationController : Controller
    {
        private OrfolioBaseEntities db = new OrfolioBaseEntities();

        public ActionResult Envoyer(int id)
        {
            var candidat = db.Candidat.Find(id);
            if (candidat == null) return HttpNotFound();

            string body = $"Bonjour {candidat.Prenom},\n\nVotre poste de {candidat.TypePoste} est confirmé.\nDébut: {candidat.DateDebut}\nModalités: {candidat.Disponibilite}\n\nLe contrat officiel suivra.";

            MailMessage message = new MailMessage("orfolio@studio.com", candidat.Courriel)
            {
                Subject = "Confirmation de collaboration",
                Body = body
            };

            SmtpClient client = new SmtpClient("smtp.yourdomain.com");
            client.Send(message);

            return RedirectToAction("Index", "Candidat");
        }
    }
}
