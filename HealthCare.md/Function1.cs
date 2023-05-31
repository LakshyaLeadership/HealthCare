using System.Collections.Generic;
using System.Net;
using HealthCare.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HealthCare.md
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly IPatientService _patientService;

        public Function1(ILoggerFactory loggerFactory, IPatientService patientService)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _patientService = patientService;
        }

        [Function("Function1")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var ssnNumber = req.ReadAsString();
            var patient = await _patientService.ReadPatientAsync(ssnNumber);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            
            await response.WriteAsJsonAsync(patient);
            

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
