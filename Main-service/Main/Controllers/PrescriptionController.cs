using Main.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [Route("/api/prescriptions")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        private PrescriptionService _service;
        public PrescriptionController(PrescriptionService service) 
        {
            _service = service;
        }
        [HttpGet("{prescriptionid}")]
        [Authorize(Roles = "Patient")]
        public Task<GetPrescriptionDTO> GetPrescriptionById(int prescriptionID) 
            {
            return null;
            }

        public Task<CreatePrescriptionDTO> CreateNewPrescription(CreatePrescriptionDTO prescription) 
        {
            return null;
        } 
    }
}
