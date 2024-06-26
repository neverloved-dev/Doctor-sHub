﻿using Main.DTOs;
using Main.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase //TODO: Implement controller with the service
    {
        private readonly DoctorService _doctorService;
        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor")]
        public Task<GetDoctorDTO> GetDoctorInfo(int id)
        {
            return null;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor")]
        public Task<GetDoctorDTO> EditDoctorData(int id)
        {
            return null;
        }

        [HttpGet("{id}/patients")]
        [Authorize(Roles = "Doctor")]
        public Task<PatientListDTO> PatientList(int id)
        {
            return null;
        }

        [HttpDelete("{id}/patients/{patientId}")]
        [Authorize(Roles ="Doctor")]
        public Task DeletePatient(int id,int patientId)
        {
            return null;
        }
        
        [HttpPut("{id}/patients/{patientId}")]
        [Authorize(Roles ="Doctor")]
        public Task<GetPatientDTO> UpdatePatientData()
        {
            return null;
        }
    }
}
