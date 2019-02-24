using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.CustomHtmlHelpers
{
    public static class CommonHelpers
    {
        //para crear un html helper debe ser del tipo MvcHtmlString
        public static MvcHtmlString SemaforoStock(this HtmlHelper helper, decimal stock)
        {
            string html = "";
            string imgUrl = "";
            if (stock > 0)
            {
                //html = "Tiene stock";
                imgUrl = "/Content/images/circulo-verde.png";
            }
            else
            {
                //html = "No tiene stock";
                imgUrl = "/Content/images/circulo-rojo.png";
            }

            TagBuilder tag = new TagBuilder("img"); //Aqui podemos poner un div y dentro del div podemos poner html
            tag.Attributes.Add("src", imgUrl);

            html = tag.ToString(TagRenderMode.SelfClosing);//indicar el modulo de renderizado

            return new MvcHtmlString(html);
        }
    }
}