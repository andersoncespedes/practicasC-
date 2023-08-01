using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using ProductosController;
using Servidor;
namespace SimpleWebServerWithRouting
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            string url = "http://localhost:8080/";
            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(url);
                listener.Start();
                Console.WriteLine("Servidor web en ejecución. Presiona Enter para detenerlo.");

                var router = new Router();
                router.AddRoute(HttpMethod.Get, "/", Server.selecionarhandler);
                router.AddRoute(HttpMethod.Post, "/data", Server.PostHandler);

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    Server.ProcessRequest(context, router);
                }
            }
        }

        // Controlador para la ruta "/"
        
    }
}