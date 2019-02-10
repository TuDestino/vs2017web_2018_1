using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService = null;
        private readonly ICategoriaService categoriaService = null;
        private readonly IMarcaService marcaService = null;

        public ProductoController()
        {
            productoService = new ProductoService();
            categoriaService = new CategoriaService();
            marcaService = new MarcaService();
        }
        // GET: Producto
        public ActionResult Index(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();            
            ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            return View(model);
        }

        // GET: Producto
        public ActionResult Index2(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            //var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            return View();
        }

        // GET: Producto
        public ActionResult Index2Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            var model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            return PartialView("Index2Resultado",model);
        }


        // GET: Producto
        public ActionResult Index3(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            return View();
        }

        // GET: Producto
        public ActionResult Index3Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            var model2 = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            JsonSerializerSettings config = new JsonSerializerSettings
            {
                ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            var model = JsonConvert.SerializeObject(model2, Formatting.Indented, config);

            return Json(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Producto producto = new Producto();
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            ViewBag.Estados = new List<int>() { 0, 1};
            return View(producto);

        }

        [HttpPost]
        public ActionResult Create(Producto model)
        {
            model.UnidadMedidaID = 1;
            model.UsuarioCreador = Guid.NewGuid();
            model.FechaCreacion = DateTime.Now;
            var result = productoService.Save(model);
            return RedirectToAction("Index2");
        }


        public ActionResult Edit(int id)
        {
            var model = productoService.GetById(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(Producto model)
        {
            var result = productoService.Save(model);
            return RedirectToAction("Index2");
        }


    }
}