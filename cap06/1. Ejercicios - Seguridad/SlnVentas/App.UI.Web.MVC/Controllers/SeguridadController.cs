using App.Domain.Interfaces;
using App.UI.Web.MVC.common;
using App.UI.Web.MVC.Controllers.Mantenimientos;
using App.UI.Web.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    public class SeguridadController : BaseController
    {
        private readonly ISeguridadService seguridadServices;

        public SeguridadController(ISeguridadService pseguridadServices)
        {
            seguridadServices = pseguridadServices;
        }

        // GET: Seguridad
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //verificar en la base de datos
            var usuario = seguridadServices.VerificarUsuario(model.Login, model.Password);
            if (usuario != null)
            {
                var claims = SecurityHelpers.CreateClaimsUsuario(usuario);
                var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                authManager.SignIn(identity);
                return Redirect(model.ReturnUrl??"~/");
            }
            else
            {
                model.MensajeValidacion = "Usuario no registrado en el sistema";
                return View(model);
            }
        }

        public ActionResult Salir()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}