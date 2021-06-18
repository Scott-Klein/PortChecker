using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PortChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client;
            string host = "220.233.193.122";
            int port = 9232;
            try
            {
                client = new TcpClient(host, port);

                string message = $"Message on Host:Port {host}:{port}";

                var stream = client.GetStream();

                byte[] messageB = System.Text.Encoding.ASCII.GetBytes(message);

                stream.Write(messageB, 0, message.Length);
                //var reader = new StreamReader(stream);


                Thread.Sleep(1500);
                if (stream.DataAvailable)
                {
                    Byte[] bytes = new Byte[256];
                    int i = stream.Read(bytes, 0, bytes.Length);
                    string response = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine(response);
                }
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("EXITING");
                System.Environment.Exit(1);
            }
            

        }
    }
}
