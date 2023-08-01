using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using ProductosController;
namespace Servidor{
    public class Server{
        // Método auxiliar para enviar respuestas de error
        public static Productos productos = new Productos();
        public static void SendErrorResponse(HttpListenerContext context, HttpStatusCode statusCode, string message)
        {
            SendResponse(context, message, statusCode);
        }
            public static void ProcessRequest(HttpListenerContext context, Router router)
        {
            if (router.TryGetHandler(context.Request.Url.AbsolutePath, out var handler))
            {
                handler(context);
            }
            else
            {
                // Manejar ruta no encontrada (404 Not Found)
                SendErrorResponse(context, HttpStatusCode.NotFound, "Ruta no encontrada");
            }
        }
        // Método auxiliar para enviar respuestas al cliente
        public static void SendResponse(HttpListenerContext context, string responseString, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST");
            context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();
        }

        public static void GetHandler(HttpListenerContext context)
        {
            string responseString = "Respuesta para el método GET";
            SendResponse(context, responseString);
        }
        public static void selecionarhandler(HttpListenerContext context)
        {
            Dictionary<int, Producto>? prod = productos.Selecionar();
            string json = JsonSerializer.Serialize(prod, new JsonSerializerOptions
            {
                WriteIndented = true // Para formatear el JSON con sangrías y espacios para una mejor legibilidad
            });
            SendResponse(context, json);
        }
        public static void Guardar(HttpListenerContext context)
        {
            string responseString = "Respuesta para el método GET";
            SendResponse(context, responseString);
        }
        // Controlador para la ruta "/data" en el método POST
        public static void PostHandler(HttpListenerContext context)
        {
            // Leer los datos enviados en la solicitud POST
            using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
            {
                string requestBody = reader.ReadToEnd();

                // Aquí puedes procesar los datos recibidos en el cuerpo de la solicitud POST
                // Por ejemplo, puedes convertir el JSON a un objeto C# utilizando System.Text.Json.JsonSerializer
                
                // Ejemplo: Convertir el JSON a un objeto C#
                try
                {
                    var data = JsonSerializer.Deserialize<MyData>(requestBody);
                    // Lógica para procesar 'data' aquí
                    productos.Guardar(data);
                    // Envía una respuesta al cliente
                    string responseString = "Respuesta para el método POST";
                    SendResponse(context, responseString);
                }
                catch (JsonException)
                {
                    // Si el JSON enviado no es válido, puedes enviar una respuesta de error
                    SendErrorResponse(context, HttpStatusCode.BadRequest, "Solicitud POST con JSON inválido");
                }
            }
        
    }
    
    }
    public class MyData
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Foto { get; set; }
        public string? Documento { get; set; }
        public string? Tipo_documento { get; set; }
        public string? Telefono { get; set; }

        public string? Tipo { get; set; } = "";
        // Agrega otras propiedades según los datos que esperas recibir en el JSON
    }
    public class Router
        {
            private Dictionary<string, Action<HttpListenerContext>> routes;

            public Router()
            {
                routes = new Dictionary<string, Action<HttpListenerContext>>();
            }

            public void AddRoute(HttpMethod method, string path, Action<HttpListenerContext> handler)
            {
                routes[path] = handler;
            }

            public bool TryGetHandler(string path, out Action<HttpListenerContext> handler)
            {
                return routes.TryGetValue(path, out handler);
            }
        }
}