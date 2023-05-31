using HealthCare.Repositories.Dto;

namespace HealthCare.Services
{
    public interface IPatientService
    {
        Task<PatientDto?> ReadPatientAsync(string? ssnNumber);
    }
}