
using Main.Models;
using Main.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainTests
{
    public class PrescriptionRepositoryTests:IDisposable
    {
        private PrescriptionRepository _repository;
        public PrescriptionRepositoryTests() 
        {
            var options = new DbContextOptionsBuilder<MainContext>()
               .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
               .Options;

            MainContext context = new MainContext(options);
            _repository = new PrescriptionRepository(context);
        }
        

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task PrescriptionRepository_Should_GetAllPerscriptionsForUser(int userId)
        {
            //Arrange
            Prescription prescription1 = new Prescription
            {
                Id = 1,
                Title = "Antibiotic",
                Description = "Take one pill every 8 hours",
                CreatedDate = DateTime.Now,
                PatientId = 1
            };
            Prescription prescription2 = new Prescription
            {
                Id = 2,
                Title = "Pain Relief",
                Description = "Take one pill as needed for pain",
                CreatedDate = DateTime.Now,
                PatientId = 2
            };
            Prescription prescription3 = new Prescription
            {
                Id = 3,
                Title = "Antidepressant",
                Description = "Take one pill every morning",
                CreatedDate = DateTime.Now,
                PatientId = 3
            };
            Prescription prescription4 = new Prescription
            {
                Id = 4,
                Title = "Allergy Medication",
                Description = "Take one pill daily",
                CreatedDate = DateTime.Now,
                PatientId = 4
            };
            _repository.AddPrescription(prescription4);
            _repository.AddPrescription(prescription3);
            _repository.AddPrescription(prescription2);
            _repository.AddPrescription(prescription1);
            //Act
            List<Prescription> result = _repository.GetPrescriptionList(userId);
            //Assert
            Assert.NotEmpty(result);
            foreach (Prescription prescription in result)
            {
                Assert.Equal(userId, prescription.PatientId);
            }

        }
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public async Task PrescriptionRepository_Should_GetPerscriptionById(int perscriptionId)
        {
            //Arrange
            Prescription prescription1 = new Prescription
            {
                Id = 5,
                Title = "Blood Pressure",
                Description = "Take one pill every morning and evening",
                CreatedDate = DateTime.Now,
                PatientId = 1005
            };
            Prescription prescription2 = new Prescription
            {
                Id = 6,
                Title = "Diabetes",
                Description = "Take one pill with each meal",
                CreatedDate = DateTime.Now,
                PatientId = 1006
            };
            Prescription prescription3 = new Prescription
            {
                Id = 7,
                Title = "Cholesterol",
                Description = "Take one pill every evening",
                CreatedDate = DateTime.Now,
                PatientId = 1007
            };
            Prescription prescription4 = new Prescription
            {
                Id = 8,
                Title = "Cholesterol",
                Description = "Take one pill every evening",
                CreatedDate = DateTime.Now,
                PatientId = 1007
            };
            _repository.AddPrescription(prescription4);
            _repository.AddPrescription(prescription3);
            _repository.AddPrescription(prescription2);
            _repository.AddPrescription(prescription1);
            //Act
            Prescription prescription = _repository.GetPrescription(perscriptionId);
            //Assert
            Assert.NotNull(prescription);
            Assert.Equal(perscriptionId, prescription.Id);
        }


        [Fact]
        public async Task PrescriptionRepository_Should_AddNewPrescription()
        {
            //Arrange
            Prescription newPrescription = new Prescription
            {
                Id = 9,
                Title = "Cholesterol",
                Description = "Take one pill every evening",
                CreatedDate = DateTime.Now,
                PatientId = 1007
            };
            //Act
            _repository.AddPrescription(newPrescription);
            //Assert
            Prescription resultPrescription = _repository.GetPrescription(9);
            Assert.NotNull(resultPrescription);
            Assert.Equal(9, resultPrescription.Id);
        }

        public void Dispose()
        {
            var options = new DbContextOptionsBuilder<MainContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
            using (var context = new MainContext(options))
            {
                context.Database.EnsureDeleted();  
            }
        }
    }
}