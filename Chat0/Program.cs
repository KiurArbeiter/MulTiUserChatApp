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
            server.msgReceivedEvent += () => Console.WriteLine("Message received!");
            server.userDisconnectedEvent += () => Console.WriteLine("User disconnected!");

            Console.WriteLine("Type '!Connect' to connect to the server.");

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
                    Console.WriteLine("Invalid command. Please type '!Connect' to connect.");
                }
            }

            while (true)
            {
                Console.WriteLine("Message: ");
                string message = Console.ReadLine();
                server.SendMessageToServer(message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
