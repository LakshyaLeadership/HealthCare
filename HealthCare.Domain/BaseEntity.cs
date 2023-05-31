using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain
{
    public class BaseEntity
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
