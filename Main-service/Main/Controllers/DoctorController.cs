using Main.DTOs;
using Main.Models;
using Main.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;
        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor")]
        public async Task<GetDoctorDTO> GetDoctorInfo(int id)
        {
            return _doctorService.GetSingleDoctor(id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor")]
        public async Task<GetDoctorDTO> EditDoctorData(Doctor doctor)
        {
            return _doctorService.UpdateDoctor(doctor);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteDoctor(int id)
        {
            _doctorService.DeleteDoctor(id);
        }
        
        // TODO: Do this with the calendar system
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
