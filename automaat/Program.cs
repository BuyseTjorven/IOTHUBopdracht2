// See https://aka.ms/new-console-template for more information
using System.Text;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using automaat.Models;




string connectionString = "HostName=tjorvenIOT.azure-devices.net;DeviceId=Machine;SharedAccessKey=r9ELFeA4Y/TwZR0GrVOGIuHSBy87lYns8p+2+VXkX3M=";
var deviceClient = DeviceClient.CreateFromConnectionString(connectionString);


#region Menu

await Loop();
async Task Loop()
{
    while (true)
    {
        Console.WriteLine("Maak uw keuze: ");
        Console.WriteLine("1. Water");
        Console.WriteLine("2. Cola");
        Console.WriteLine("3. Fruitsap");
        Console.WriteLine("4. Afsluiten");
        string keuze = Console.ReadLine();
        await ProcessChoice(keuze);

    }
}

async Task ProcessChoice(string choise)
{
    switch (choise)
    {
        case "1":
            await SendWater();
            break;
        case "2":
            await SendCola();
            break;
        case "3":
            await SendFruitsap();
            break;
        case "4":
            break;
        default:
            Console.WriteLine("Ongeldige keuze");
            break;
    }
}

Task SendWater()
{
    OrderMessage orderMessage = new OrderMessage();
    {
        orderMessage.Product = "Water";
        orderMessage.Amount = 1;
        orderMessage.UnitPrice = 1.50m;
        orderMessage.TotalPrice = 1.50m;
        orderMessage.Location = "A1";
    }
    var json = JsonConvert.SerializeObject(orderMessage);
    var bytes = Encoding.UTF8.GetBytes(json);
    var message = new Message(bytes);
    Console.WriteLine("Water besteld");
    return deviceClient.SendEventAsync(message);
}
async Task SendCola()
{
    OrderMessage orderMessage = new OrderMessage();
    {
        orderMessage.Product = "Cola";
        orderMessage.Amount = 1;
        orderMessage.UnitPrice = 2.00m;
        orderMessage.TotalPrice = 2.00m;
        orderMessage.Location = "A2";
    }
    var json = JsonConvert.SerializeObject(orderMessage);
    var bytes = Encoding.UTF8.GetBytes(json);
    var message = new Message(bytes);
    Console.WriteLine("cola besteld");
    await deviceClient.SendEventAsync(message);
}
Task SendFruitsap()
{
    OrderMessage orderMessage = new OrderMessage();
    {
        orderMessage.Product = "Fruitsap";
        orderMessage.Amount = 1;
        orderMessage.UnitPrice = 2.50m;
        orderMessage.TotalPrice = 2.50m;
        orderMessage.Location = "A3";
    }
    var json = JsonConvert.SerializeObject(orderMessage);
    var bytes = Encoding.UTF8.GetBytes(json);
    var message = new Message(bytes);
    Console.WriteLine("fruitsap besteld");
    return deviceClient.SendEventAsync(message);
}


#endregion

