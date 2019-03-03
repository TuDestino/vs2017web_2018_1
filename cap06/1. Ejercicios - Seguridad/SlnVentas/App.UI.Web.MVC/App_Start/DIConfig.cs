using App.Domain.Interfaces;
using App.Domain.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.App_Start
{
    public static class DIConfig
    {
        public static void ConfigureInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();//Le indicamos en que momento se va inyectar el componente

            //Se configura los componentes que se quieren inyectar en el proyecto
            container.Register<ICategoriaService, CategoriaService>();
            container.Register<IMarcaService, MarcaService>();
            container.Register<IUnidadMedidaService, UnidadMedidaService>();
            container.Register<IProductoService, ProductoService>();
            container.Register<ISeguridadService, SeguridadService>();
            container.Register<IComentarioService, ComentarioService>();
            //en que entorno se va ejecutar
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            //verificar
            container.Verify();
            DependencyResolver.SetResolver( new SimpleInjectorDependencyResolver(container));
        }
    }
}