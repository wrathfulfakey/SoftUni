namespace HttpRequester
{
    using System;
    using System.IO;
    using System.Text;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class Program
    {
        static Dictionary<string, int> SessionStore = new Dictionary<string, int>();

        public async static Task Main()
        {

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() => ProcessClientAsync(tcpClient));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
        }

        private static async Task ProcessClientAsync(TcpClient tcpClient)
        {
            const string NewLine = "\r\n";

            using NetworkStream networkStream = tcpClient.GetStream();

            byte[] requestBytes = new byte[1000000];
            int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

            byte[] fileContent = File.ReadAllBytes("istock-1069317442.jpg");
            string headers = "HTTP/1.0 307 OK" + NewLine +
                              "Server: SoftUniServer/1.0" + NewLine +
                              "Content-Type: image/jpg" + NewLine +
                              "Set-Cookie: user=Vlado; Max-Age=3600; HttpOnly;" + NewLine +
                              "Content-Length: " + fileContent.Length + NewLine +
                              NewLine;
            byte[] headersBytes = Encoding.UTF8.GetBytes(headers);
            await networkStream.WriteAsync(headersBytes, 0, headersBytes.Length);
            await networkStream.WriteAsync(fileContent);

            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));
        }
    }
}
