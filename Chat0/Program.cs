using Chat0.net;
using System.Net.Sockets;

try
{
    string name;
    string message;

    Console.WriteLine("Nimi: ");
    name = Console.ReadLine();
    Server server = new Server();
    server.ConnectToServer(name);
    Console.WriteLine("Message: ");
    message = Console.ReadLine();
    server.SendMessageToServer(message);

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}