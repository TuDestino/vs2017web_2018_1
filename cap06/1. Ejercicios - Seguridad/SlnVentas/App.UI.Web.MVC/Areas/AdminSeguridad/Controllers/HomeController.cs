using App.Domain.Interfaces;
using App.UI.Web.MVC.Controllers.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Areas.Seguridad.Controllers
{
    [Authorize(Roles = ("Admin"))]
    public class HomeController : BaseController
    {
        private readonly ISeguridadService seguridadServices;

        public HomeController(ISeguridadService pseguridadServices)
        {
            seguridadServices = pseguridadServices;
        }
        // GET: Seguridad/Home
        public ActionResult Index()
        {
            var model = seguridadServices.GetAll("");
            return View(model);
        }

        public ActionResult Buscar(string filtroPorNombre)
        {
            filtroPorNombre = (filtroPorNombre != null ? filtroPorNombre : "");
            var model = seguridadServices.GetAll(filtroPorNombre);
            return PartialView("_IndexListado", model);
        }
    }
}