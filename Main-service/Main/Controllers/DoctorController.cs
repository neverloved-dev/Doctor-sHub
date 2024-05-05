using Main.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
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
