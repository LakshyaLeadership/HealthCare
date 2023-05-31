using HealthCare.Repositories;
using HealthCare.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(x => { 
        x.AddScoped<IPatientRepository, PatientRepository>();
        x.AddScoped<IPatientService, PatientService>();
    })
    .Build();

host.Run();
