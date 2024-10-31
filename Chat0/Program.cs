using Chat0.net;
using Chat0.Net.IO;
using Chat0;
using System;
using static System.Net.Mime.MediaTypeNames;
using Chat0;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter name to connect: ");
        string name = Console.ReadLine();
        var input = new MainViewModel(name);


        while (true)
        {
            string message = Console.ReadLine();
            input.SendMessage(message);
        }
    }
}


        //try
        //{

        //    server.connectedEvent += () => Console.WriteLine("Connected to the server!");
        //    server.userDisconnectedEvent += () => Console.WriteLine("User disconnected!");

        //    Console.WriteLine("Use '!Connect' to connect to the server");

        //    while (true)
        //    {
        //        string input = Console.ReadLine();

        //        if (input.Equals("!Connect", StringComparison.OrdinalIgnoreCase))
        //        {
        //            if (string.IsNullOrEmpty(name))
        //            {
        //                Console.WriteLine("Name: ");
        //                name = Console.ReadLine();
        //            }
        //            server.ConnectToServer(name);
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid command. Write '!Connect' to connect");
        //        }
        //    }

