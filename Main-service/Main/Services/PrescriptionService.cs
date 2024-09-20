
﻿using Main.DTOs;
using Main.Models;
using Main.Repositories;
using Microsoft.JSInterop.Infrastructure;

namespace Main.Services
{
    public class PrescriptionService
    {
        private PrescriptionRepository _repository;
        public PrescriptionService(PrescriptionRepository repository)
        {
            _repository = repository;
        }
        public List<GetPrescriptionDTO> GetPrescriptionDtosById(int patientId)
        {
            List<GetPrescriptionDTO> resList = new List<GetPrescriptionDTO>();
            var list = _repository.GetPrescriptionList(patientId);
            foreach (var prescription in list)
            {
                GetPrescriptionDTO dto = new GetPrescriptionDTO();
                dto.PatientId = prescription.PatientId;
                dto.Description = prescription.Description;
                dto.CreatedDate = prescription.CreatedDate;
                dto.Title = prescription.Title;
                resList.Add(dto);
            }

            return resList;
        }

        public void CreateNewPrescription(CreatePrescriptionDTO dto)
        {
            Prescription prescription = new Prescription();
            prescription.Description = dto.Description;
            prescription.PatientId = dto.PatientId;
            prescription.CreatedDate = dto.CreatedDate;
            prescription.Title = dto.Title;
            _repository.AddPrescription(prescription);
        }

        public GetPrescriptionDTO GetPrescriptionById(int prescriptionId)
        {
            var prescription = _repository.GetPrescription(prescriptionId);
            GetPrescriptionDTO dto = new GetPrescriptionDTO();
            dto.Description = prescription.Description;
            dto.Title = prescription.Title;
            dto.CreatedDate = prescription.CreatedDate;
            dto.PatientId = prescription.PatientId;
            return dto;
        }

}
