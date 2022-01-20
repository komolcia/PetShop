using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Custom
{
    public static class ImageHelper
    { 
            public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, string height)
            {
            var builder = new TagBuilder("img");

            builder.MergeAttribute("src", src);

            builder.MergeAttribute("alt", altText);

            builder.MergeAttribute("height", height);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
            }
        public static MvcHtmlString MyCustomLabel(this HtmlHelper helper,string text)
        {
            var tagBuilder = new TagBuilder("label");
            tagBuilder.AddCssClass("myLabel");
            tagBuilder.InnerHtml = text;
            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
}