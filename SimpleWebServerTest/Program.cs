using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SimpleWebServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:80/");
            listener.Start();
            Console.WriteLine("Listening...");
            while (true)
            {
                var context = listener.GetContext();
                var request = context.Request;
                // Obtain a response object.
                var response = context.Response;
                // Construct a response.
                var writer = new StreamWriter(response.OutputStream);
                writer.WriteLine($"<HTML><BODY> Hello world! {DateTime.Now:F}</BODY></HTML>");
                //writer.WriteLine("{name: 'Terje', city: 'Stavern'}");
                writer.Close();
            }
            listener.Stop();
        }
    }
}
