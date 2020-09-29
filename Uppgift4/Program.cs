using Microsoft.Azure.Devices.Client;
using SharedLibrary.Models;
using SharedLibrary.Services;
using System;
using System.Threading.Tasks;

namespace Uppgift4
{
    class Program
    {
        private static readonly string _con = "HostName=ec-win20-iot.azure-devices.net;DeviceId=consoleApp;SharedAccessKey=trjeNWK9YXTwRegt3edRN4qbFJhs9QkW+xGI2joPFoc=";
        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(_con, TransportType.Mqtt );

        /* static void Main (string[] args)
         * {
                DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
           }*/
        //static async Task Main(string[] args)
        //{
        //    await DeviceService.SendMessageAsync(deviceClient);

        //    await DeviceService.ReceivedMessageAsync(deviceClient);

        //    Console.ReadKey();
        //}
        static void Main(string[] args)
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();



            DeviceService.ReceivedMessageAsync(deviceClient).GetAwaiter();



            Console.ReadKey();
        }
    }
}
