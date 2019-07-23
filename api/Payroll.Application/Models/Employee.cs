using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Payroll.Application.Models
{
    [Serializable]
    [BindProperties(SupportsGet = true)]
    public class Employee
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("dependents")]
        public int Dependents { get; set; }
    }
}
