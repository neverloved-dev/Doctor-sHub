namespace MainTests
{
    public class DoctorRepositoryTests
    {

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(2)]
        public void DoctorRepository_ReturnPatients_Paginated(int doctorId)
        {

        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(2)]
        public void DoctorRepository_DeletePatient(int patientId) 
        {

        }

        [Fact]
        public void DoctorRepository_DeleteDoctor()
        {

        }

        [Fact]
        public void DoctorRepository_UpdatePatientData()
        {

        }

        [Fact]
        public void DoctorRepostiory_GetDoctorData()
        {

        }

        [Fact]
        public void DoctorRepository_UpdateDoctorData()
        {

        }
    }
}