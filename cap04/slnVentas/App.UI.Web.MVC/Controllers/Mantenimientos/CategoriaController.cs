﻿using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService categoriaService = null;

        public CategoriaController()
        {
            categoriaService = new CategoriaService();
        }

       
        public ActionResult Index()
        {
            var model = categoriaService.GetAll("");
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create([ModelBinder(binderType:typeof(CategoriaBinder))]Categoria model)
        {
            var result = categoriaService.Save(model);
            return RedirectToAction("Index");
        }

        
        public ActionResult Edit(int id)
        {
            var model = categoriaService.GetById(id);
            return View("Create",model);
        }

        [HttpPost]
        public ActionResult Edit(Categoria model)
        {
            var result = categoriaService.Save(model);
            return RedirectToAction("Index");
        }

    }
}