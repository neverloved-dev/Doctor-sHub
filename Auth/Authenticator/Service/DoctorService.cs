using Authenticator.DTOs;
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
    }
}
