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
        
        public  List<GetDoctorDTO>? GetDoctorsPaginated(int pageNumber,int pageSize)
        {
            var doctors = _doctorRepository.GetDoctorPaginated(pageNumber, pageSize);
            if (doctors == null) return null;
            List<GetDoctorDTO> finalList = new List<GetDoctorDTO>();
            foreach (var doctor in doctors)
            {
                GetDoctorDTO dto = new GetDoctorDTO();
                dto.Speciality = doctor.Specialization;
                dto.LastName = doctor.LastName;
                dto.Name = doctor.Name;
                dto.YearsOfExperience = doctor.YearsOfExperience;
                finalList.Add(dto);
            }

            return finalList;
        }

        public void DeleteDoctor(int id)
        {
            _doctorRepository.Delete(id);
        }
        
        // TODO: After finding the calendar algorithm

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