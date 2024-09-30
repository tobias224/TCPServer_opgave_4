using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

Console.WriteLine("TCP Server:");

TcpListener listener = new TcpListener(IPAddress.Any, 7);
listener.Start();

while (true)
{
    TcpClient socket = listener.AcceptTcpClient();
    Task.Run(() => HandleClient(socket));
}

void HandleClient(TcpClient socket)
{
    NetworkStream ns = socket.GetStream();
    StreamReader reader = new StreamReader(ns);
    StreamWriter writer = new StreamWriter(ns);

    while (socket.Connected)
    {
        string message = reader.ReadLine().ToLower();
        //Console.WriteLine(message);
        //writer.WriteLine(message);
        //writer.Flush();

        if (message == "stop")
        {
            writer.Close();
        }
        else if (message == "random")
        {

            writer.WriteLine("Input numbers");
            writer.Flush();

            string tal = reader.ReadLine();
            string[] alletal = tal.Split(" ");


            int a = Int32.Parse(alletal[1]);
            int b = Int32.Parse(alletal[2]);


            Random rnd = new Random();

            int temp = rnd.Next(a, b); 
            writer.Write(temp.ToString());
            writer.Flush();

        }
        else if (message.Contains(""))
        {
            // det skal være et string array, da input fra client er string
            string[] tal = message.Split(" ");
            writer.WriteLine("Input numbers");
            writer.Flush();

            int a = Int32.Parse(tal[0]);
            int b = Int32.Parse(tal[1]);

            writer.WriteLine("");
            
            writer.Flush();
        }
        else if (message.Contains("add"))
        {
            writer.WriteLine("Input numbers");
            writer.Flush();

            string tal = reader.ReadLine();
            string[] alletal = tal.Split(" ");
          

            int a = Int32.Parse(alletal[0]);
            int b = Int32.Parse(alletal[1]);

            int result = b + a;

            writer.WriteLine($"result = {result}");
            writer.Flush();
        }
        else if (message.Contains("Subtract"))
        {
            writer.WriteLine("Input numbers");
            writer.Flush();

            string tal = reader.ReadLine();
            string[] alletal = tal.Split(" ");


            int a = Int32.Parse(alletal[0]);
            int b = Int32.Parse(alletal[1]);

            int result = b / a;

            writer.WriteLine($"result = {result}");
            writer.Flush();
        }
    }
}