using AutoMapper;
using HealthCare.Domain.Aggregates;
using HealthCare.Repositories.Dto;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System;

namespace HealthCare.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly CosmosClient cosmosClient;
        private readonly ILogger<PatientRepository> logger;
        private readonly IMapper mapper;
        private readonly string containerName = "Pass as parameter or read from config";
        private readonly string databaseName = "Pass as parameter or read from config";

        public PatientRepository(CosmosClient cosmosClient,
            ILogger<PatientRepository> logger,
            IMapper mapper)
        {
            this.cosmosClient = cosmosClient;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<PatientDto?> ReadPatientAsync(string ssnNumber)
        {
            logger.LogInformation($"Entered into method: ${nameof(ReadPatientAsync)}");

            var container = cosmosClient.GetContainer(databaseName, containerName);
            var queryText = $"SELECT * FROM c WHERE c.id = '{ssnNumber}'";
            var queryDefinition = new QueryDefinition(queryText);

            var iterator = container.GetItemQueryIterator<Patient>(queryDefinition);

            if (iterator.HasMoreResults)
            {
                FeedResponse<Patient> response = await iterator.ReadNextAsync();

                return mapper.Map<PatientDto>(response);
            }

            logger.LogInformation($"Exiting from method: ${nameof(ReadPatientAsync)}");

            return null; // Patient not found
        }
    }
}