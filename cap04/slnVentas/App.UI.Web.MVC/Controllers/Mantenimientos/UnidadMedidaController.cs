using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class UnidadMedidaController : Controller
    {
        private readonly IUnidadMedidaService unidadMedidaService = null;

        public UnidadMedidaController()
        {
            unidadMedidaService = new UnidadMedidaService();
        }

        
        public ActionResult Index()
        {
            var model = unidadMedidaService.GetAll("");
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(UnidadMedida model)
        {
            var result = unidadMedidaService.Save(model);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var model = unidadMedidaService.GetById(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(UnidadMedida model)
        {
            var result = unidadMedidaService.Save(model);
            return RedirectToAction("Index");
        }
    }
}