using HealthCare.Repositories.Dto;

namespace HealthCare.Repositories
{
    public interface IPatientRepository
    {
        Task<PatientDto?> ReadPatientAsync(string ssnNumber);
    }
}