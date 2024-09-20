
﻿using Main.DTOs;
using Main.Services;
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
        public async Task<GetPrescriptionDTO> GetPrescriptionById(int prescriptionID)
        {
           return _service.GetPrescriptionById(prescriptionID);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public void CreateNewPrescription(CreatePrescriptionDTO prescription) 
        {
            _service.CreateNewPrescription(prescription);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "Doctor")]
        public async Task<List<GetPrescriptionDTO>> GetPrescriptionForUser(int userId)
        {
            return _service.GetPrescriptionDtosById(userId);
        }
    }
}
