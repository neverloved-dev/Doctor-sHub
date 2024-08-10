using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Main.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace MainTests.PrescriptionTests
{
    public class PrescriptionControllerTests:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PrescriptionControllerTests(WebApplicationFactory<Program> client)
        {
            _client = client.CreateClient();
        }
        
        
        [Fact]
        public async Task GetPrescriptionById_ReturnsPrescription()
        {
            int prescriptionId = 1;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "valid_patient_token");

            var response = await _client.GetAsync($"/api/prescriptions/{prescriptionId}");

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var prescription = JsonConvert.DeserializeObject<GetPrescriptionDTO>(jsonString);
            Assert.NotEmpty(prescription.Title);
        }

        [Fact]
        public async Task CreateNewPrescription_CreatesPrescription()
        {
            var newPrescription = new CreatePrescriptionDTO { Title = "New Prescription", CreatedDate = DateTime.Now, Description = "Description"};
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "valid_doctor_token");

            var content = new StringContent(JsonConvert.SerializeObject(newPrescription), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/prescriptions", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetPrescriptionForUser_ReturnsPrescriptions()
        {
            int userId = 1;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "valid_doctor_token");

            var response = await _client.GetAsync($"/api/prescriptions/{userId}");

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var prescriptions = JsonConvert.DeserializeObject<List<GetPrescriptionDTO>>(jsonString);
            Assert.NotEmpty(prescriptions);
            foreach (var prescription in prescriptions)
            {
                Assert.Equal(userId,prescription.PatientId);
            }
        }
    }
    
}