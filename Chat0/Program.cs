using System;
using Chat0.net;

class Program
{
    static void Main()
    {
        try
        {
            string name = string.Empty;
            Server server = new Server();

            server.connectedEvent += () => Console.WriteLine("Connected to the server!");
            server.userDisconnectedEvent += () => Console.WriteLine("User disconnected!");
            server.msgReceivedEvent += () => Console.WriteLine("Message recieved");


            Console.WriteLine("Use '!Connect' to connect to the server");

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("!Connect", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Nimi: ");
                        name = Console.ReadLine();
                    }
                    server.ConnectToServer(name);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command Write '!Connect' to connect");
                }
            }
            while (true)
            {
            Console.WriteLine("Message: ");
            string message = Console.ReadLine();
                server.SendMessageToServer(message);
                server.msgReceivedEvent += () => Console.WriteLine(message);
            }

            while (true)
            {
            string input = Console.ReadLine();
            if (input.Equals("!Disconnect", StringComparison.OrdinalIgnoreCase))
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine();
                name = Console.ReadLine();
            }
            Environment.Exit(0); 
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR");
        }
    }
}
