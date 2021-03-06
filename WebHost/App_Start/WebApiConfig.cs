﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web;
using Ivony.TableGame.WebHost;

[assembly: PreApplicationStartMethod( typeof( WebApiConfig ), "Initialize" )]

namespace Ivony.TableGame.WebHost
{

  public static class WebApiConfig
  {

    public static void Initialize()
    {
      GlobalConfiguration.Configure( WebApiConfig.Register );

    }



    public static void Register( HttpConfiguration config )
    {
      // Web API 配置和服务
      config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
      config.Services.Replace( typeof( IContentNegotiator ), new JsonContentNegotiator() );

      config.MessageHandlers.Add( new PlayerHostHttpHandler() );

      JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
      jsonSetting.Converters.Add( new StringEnumConverter() );
      config.Formatters.JsonFormatter.SerializerSettings = jsonSetting;



      // Web API 路由
      config.Routes.MapHttpRoute( name: "Default", routeTemplate: "{action}", defaults: new { controller = "GameHost", action = "Status" } );


      config.Routes.MapHttpRoute( name: "Responding", routeTemplate: "Responding/{id}", defaults: new { controller = "Responding" } );
      config.Routes.MapHttpRoute( name: "Player", routeTemplate: "Player/{action}", defaults: new { controller = "Player" } );
      config.Routes.MapHttpRoute( name: "GameRooms", routeTemplate: "GameRooms/{action}", defaults: new { controller = "GameRooms" } );
    }
  }
}
