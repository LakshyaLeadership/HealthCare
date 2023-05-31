using AutoMapper;
using HealthCare.Domain.Aggregates;
using HealthCare.Repositories;
using HealthCare.Repositories.Dto;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace HealthCare.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public async Task<PatientDto?> ReadPatientAsync(string ssnNumber)
        {
            return await patientRepository.ReadPatientAsync(ssnNumber).ConfigureAwait(false);
        }
    }
}