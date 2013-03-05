﻿using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using Glass.Mapper.Sc.Razor.Web.Mvc;
using Sitecore.Data;

namespace Glass.Mapper.Sc.Razor.Pipelines.GetRenderer
{
    public class GetBehindViewRendering : AbstractGetViewRendering
    {
        protected override global::Sitecore.Mvc.Presentation.Renderer GetRenderer(
            global::Sitecore.Mvc.Presentation.Rendering rendering, 
            GetRendererArgs args)
        {

            var renderItem = rendering.Item.Database.GetItem(new ID(rendering.RenderingItemPath));
            if (renderItem.TemplateName == "GlassBehindRazor")
            {
                BehindViewRenderer render = new BehindViewRenderer();
                render.Path = renderItem["Name"];
                render.Type = renderItem["Type"];
                render.Assembly = renderItem["assembly"];

                render.DataSource = rendering.DataSource;
                return render;
            }

            return null;
        }
    }
}