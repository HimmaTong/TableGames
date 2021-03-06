﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ivony.TableGame.ConsoleClient
{
  class Program
  {




    static void Main( string[] args )
    {

      var url = new Uri( ConfigurationManager.AppSettings["server"] ?? "http://game.jumony.net/" );

      client = new GameClient( url );

      SetConsoleCtrlHandler( handler, true );

      client.Run().Wait();


    }


    private static GameClient client;
    private static readonly HandlerRoutine handler = OnExit;

    private static bool OnExit( int controlType )
    {
      if ( client != null )
        client.Dispose();
      return false;
    }

    private delegate bool HandlerRoutine( int controlType );

    [DllImport( "kernel32.dll", CharSet = CharSet.Auto )]
    private static extern bool SetConsoleCtrlHandler( HandlerRoutine HandlerRoutine, bool add );

  }
}
