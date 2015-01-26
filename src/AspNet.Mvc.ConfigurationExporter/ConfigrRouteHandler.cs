﻿using System.Web;
using System.Web.Routing;
using AspNet.Mvc.ConfigurationExporter.Section;

namespace AspNet.Mvc.ConfigurationExporter
{
    public class ConfigrRouteHandler : IRouteHandler
    {
        private readonly IConfigrSectionHandler _configuration;

        public ConfigrRouteHandler()
        {
            _configuration = ConfigrSectionHandler.GetConfig();
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var appSettingsProvider = new AppSettingsProvider();
            return new ConfigrHandler(requestContext, new ConfigrSettingsSerializer(_configuration), appSettingsProvider,
                new ScriptBuilder(appSettingsProvider));
        }
    }
}