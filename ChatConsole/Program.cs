using ChatApp.Net.IO;
using ChatConsole;
using ChatApp;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using ChatConsole.ViewModel;
using ChatConsole.Model;

class Program
{


    static void Main()
    {
        Console.WriteLine("Enter name to connect");
        var name = Console.ReadLine();
        var message = string.Empty;
        var input = new MainViewModel(name);


        while (true)
        {
            message = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(message))
            {
                input.SendMessage(message);
            }
            else
            {
                Console.WriteLine("Message cannot be empty. Please try again.");
            }
        }



    }
}