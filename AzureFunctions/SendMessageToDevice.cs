using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedLibrary.Models;
using SharedLibrary.Services;
using Microsoft.Azure.Devices;

namespace AzureFunctions
{
    public static class SendMessageToDevice
    {
        private static readonly ServiceClient serviceClient = ServiceClient.CreateFromConnectionString("HostName=ec-win20-iot.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=HGF318p9cXiMdr/yRg4SLxOt7aeCNyK9Bw2bNxSOn8w=");

        [FunctionName("SendMessageToDevice")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string targetDeviceId = req.Query["targetdeviceid"];
            string message = req.Query["message"];



            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var data = JsonConvert.DeserializeObject<BodyMessageModel>(requestBody);

            targetDeviceId = targetDeviceId ?? data?.TargetDeviceId;

            message = message ?? data?.Message;

           
               await DeviceService.SendMessageToDeviceAsynic(serviceClient, targetDeviceId, message);

            return new OkResult();
        }
    }
}
