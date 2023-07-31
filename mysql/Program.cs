using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using ProductosController;
namespace SimpleWebServerWithRouting
{
    class Program
    {
        static public Productos productos = new();
        static void Main(string[] args)
        {
            string url = "http://localhost:8080/";
            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(url);
                listener.Start();
                Console.WriteLine("Servidor web en ejecución. Presiona Enter para detenerlo.");

                // Registrar las rutas y sus controladores
                var router = new Router();
                router.AddRoute("/Productos", IndexHandler);
                router.AddRoute("/about", selecionarhandler);

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    ProcessRequest(context, router);
                }
            }
        }

        // Controlador para la ruta "/"
        static void IndexHandler(HttpListenerContext context)
        {
            Dictionary<int, Producto> data = productos.Selecionar();
              string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true // Para formatear el JSON con sangrías y espacios para una mejor legibilidad
            });
            SendResponse(context, jsonString);
        }

        // Controlador para la ruta "/about"
        static void selecionarhandler(HttpListenerContext context)
        {
            string responseString = "<html><body><h1>Esta es la página Acerca de</h1></body></html>";

            SendResponse(context, responseString);
        }

        // Procesar las rutas y dirigirlas a los controladores correspondientes
        static void ProcessRequest(HttpListenerContext context, Router router)
        {
            string path = context.Request.Url.AbsolutePath;
            if (router.TryGetHandler(path, out var handler))
            {
                handler(context);
            }
            else
            {
                // Manejar ruta no encontrada (404 Not Found)
                string responseString = "<html><body><h1>Error 404: Ruta no encontrada</h1></body></html>";
                SendResponse(context, responseString, HttpStatusCode.NotFound);
            }
        }

        // Clase para manejar las rutas y sus controladores
        class Router
        {
            private Dictionary<string, Action<HttpListenerContext>> routes;

            public Router()
            {
                routes = new Dictionary<string, Action<HttpListenerContext>>();
            }

            public void AddRoute(string path, Action<HttpListenerContext> handler)
            {
                routes[path] = handler;
            }

            public bool TryGetHandler(string path, out Action<HttpListenerContext> handler)
            {
                return routes.TryGetValue(path, out handler);
            }
        }

        // Método auxiliar para enviar la respuesta HTTP al cliente
        static void SendResponse(HttpListenerContext context, string jsonString, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            // Establecer el encabezado "Content-Type" en "application/json"
            context.Response.ContentType = "application/json";

            // Convertir el JSON en bytes y enviarlo en el flujo de salida de la respuesta
            byte[] buffer = Encoding.UTF8.GetBytes(jsonString);
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();
        }
    }
}