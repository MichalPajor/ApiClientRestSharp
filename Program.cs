using ApiClientRestSharp.DTOs;
using ApiClientRestSharp.Utils;

namespace ApiClientRestSharp
{
    class Program
    {
        private static bool running = true;
        static void Main()
        {
            while (running)
            {
                Console.WriteLine("API MENU:\n");
                Console.WriteLine("1) Create command.");
                Console.WriteLine("2) Get command by id.");
                Console.WriteLine("3) Get all commands.");
                Console.WriteLine("4) Update command.");
                Console.WriteLine("5) Delete command.");
                Console.WriteLine("0) Exit.");
                Console.Write("Option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        Console.WriteLine("\n--- CREATE ---");
                        Console.WriteLine("\n--- Create new object ---\n");
                        CommandCreateDto dataToSend = new CommandCreateDto();
                        Console.Write("--- Type command line: ");
                        dataToSend.CommandLine = Console.ReadLine();
                        Console.Write("\n--- Type how to: ");
                        dataToSend.HowTo = Console.ReadLine();
                        Console.Write("\n--- Type platform: ");
                        dataToSend.Platform = Console.ReadLine();
                        Console.Write("\n--- Executing... ");
                        Rest.SendRequest(RestSharp.Method.Post, "", dataToSend);
                        break;
                    case "2":
                        Console.WriteLine("\n--- GET BY ID ---");
                        Console.Write("\n--- Type id: ");
                        var id = Console.ReadLine();
                        Console.Write("\n--- Executing... ");
                        Rest.SendRequest(RestSharp.Method.Get, "/" + id);
                        break;
                    case "3":
                        Console.WriteLine("\n--- GET ALL ---");
                        Console.Write("\n--- Executing... ");
                        Rest.SendRequest(RestSharp.Method.Get);
                        break;
                    case "4":
                        Console.WriteLine("\n--- UPDATE ---");
                        Console.Write("\n--- Type id: ");
                        var idUpdate = Console.ReadLine();
                        Console.WriteLine("\n--- Update object ---\n");
                        CommandCreateDto dataToSendUpdate = new CommandCreateDto();
                        Console.Write("--- Type command line: ");
                        dataToSendUpdate.CommandLine = Console.ReadLine();
                        Console.Write("\n--- Type how to: ");
                        dataToSendUpdate.HowTo = Console.ReadLine();
                        Console.Write("\n--- Type platform: ");
                        dataToSendUpdate.Platform = Console.ReadLine();
                        Console.Write("\n--- Executing... ");
                        Rest.SendRequest(RestSharp.Method.Put, "/" + idUpdate, dataToSendUpdate);
                        break;
                    case "5":
                        Console.WriteLine("\n--- DELETE ---");
                        Console.Write("\n--- Type id: ");
                        var idDel = Console.ReadLine();
                        Console.Write("\n--- Executing... ");
                        Rest.SendRequest(RestSharp.Method.Delete, "/" + idDel);
                        break;
                    default:
                        System.Console.WriteLine("\n*Incorrect option!\n");
                        break;
                }
                Console.ReadLine();
            }

        }
    }
}