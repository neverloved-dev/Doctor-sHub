using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.DTOs;
using Main.Models;
using Main.Repositories;

namespace Main.Services
{
    public class DoctorService
    {
        private readonly DoctorRepository _doctorRepository;
        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        
        public GetDoctorDTO GetSingleDoctor(int doctorId)
        {
            GetDoctorDTO? dto = new GetDoctorDTO();
            var doctor = _doctorRepository.GetSingle(doctorId);
            if (doctor == null) return null;
            dto.YearsOfExperience = doctor.YearsOfExperience;
            dto.Name = doctor.Name;
            dto.LastName = doctor.LastName;
            dto.Speciality = doctor.Specialization;
            return dto;

        }

        public GetDoctorDTO UpdateDoctor(Doctor updateDoctor)
        {
           var newDoctor = _doctorRepository.Update(updateDoctor);
           GetDoctorDTO dto = new GetDoctorDTO();
           dto.Speciality = newDoctor.Specialization;
           dto.YearsOfExperience = newDoctor.YearsOfExperience;
           dto.Name = newDoctor.Name;
           dto.LastName = newDoctor.LastName;
           return dto;
        }

        public void AddNewDoctor(CreateDoctorDTO requestDto)
        {
            Doctor newDoctor = new Doctor();
            newDoctor.YearsOfExperience = requestDto.YearsOfExperience;
            newDoctor.Name = requestDto.Name;
            newDoctor.Specialization = requestDto.Specialization;
            newDoctor.LastName = requestDto.LastName;
            _doctorRepository.Create(newDoctor);
        }
        
        public  List<GetDoctorDTO>? GetDoctorsPaginated()
        {
            return null;
        }

        public void DeleteDoctor(int id)
        {
            _doctorRepository.Delete(id);
        }

        public List<GetPatientDTO>? ReturnPatientsForDoctor(int doctorId)
        {
            return null;
        }

        public GetPatientDTO? ReturnPatientForDoctor(int doctorId, int patientId)
        {
            return null;
        }
    }
}