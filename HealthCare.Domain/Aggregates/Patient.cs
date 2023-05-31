using Newtonsoft.Json;

namespace HealthCare.Domain.Aggregates
{
    public class Patient
    {
        [JsonProperty("id")]
        public string SsnNumber { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("dateOfAdmission")]
        public DateTime DateOfAdmission { get; set; }

        [JsonProperty("admittedFor")]
        public string AdmittedFor { get; set; }
    }

}