﻿using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Responses
{
    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';
        public ViewResponse(string viewName, string controllerName) : base("", ContentType.Html)
        {
            if (viewName.Contains(PathSeparator) == false)
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            string viewPath = Path.GetFullPath($"./Views/" + viewName.TrimStart(PathSeparator) + ".cshtml");

            string viewContent = File.ReadAllText(viewPath);

            Body = viewContent;
        }
    }
}