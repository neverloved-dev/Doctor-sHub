using Authenticator.DTOs;
using Authenticator.Models;
using Authenticator.Repository;

namespace Authenticator.Service
{
    public class DoctorService
    {
        private DoctorRepository repository;
        public DoctorService(DoctorRepository doctorRepository)
        {
            repository = doctorRepository;
        }
        public List<GetDoctorDTO> GetAll()
        {
            var doctorObbjects = repository.GetAll();
            List<GetDoctorDTO> getDoctorDTOs = new List<GetDoctorDTO>();
            foreach(var doctor in doctorObbjects)
            {
                GetDoctorDTO finalObject = doctor.MapToGetDTO();
                getDoctorDTOs.Add(finalObject);

            }
            return getDoctorDTOs;
        }
        public GetDoctorDTO GetDoctor(int doctorId) 
        {
            var doctorObject = repository.GetSingle(doctorId);
            GetDoctorDTO getDoctorDTO = doctorObject.MapToGetDTO();
            return getDoctorDTO;
        }

        public void CreateDoctor(DoctorRegisterDTO registerDoctorDto)
        {
            Doctor doctor = new Doctor();
            doctor.LastName = registerDoctorDto.LastName;
            doctor.Name = registerDoctorDto.Name;
            doctor.YearsOfExperience = registerDoctorDto.YearsOfExperience;
            doctor.Specialization = registerDoctorDto.Specialization;
            repository.Create(doctor);
        }

        public GetDoctorDTO EditDoctorData(Doctor doctor)
        {
            Doctor finalDoctorData = repository.Update(doctor);
            GetDoctorDTO doctorDTO = finalDoctorData.MapToGetDTO();
            return doctorDTO;
        }

        public void DeleteDoctor(int doctorId)
        {
            repository.Delete(doctorId);
        }
    }
}
