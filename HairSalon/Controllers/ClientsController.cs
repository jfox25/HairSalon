using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {

      public ActionResult Index()
      {
        return View();
      }

    }
}