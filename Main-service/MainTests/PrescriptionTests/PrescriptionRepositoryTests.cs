
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
        PrescriptionRepository repository;
        public PrescriptionRepositoryTests() 
        {
            var db = GetInMemoryContext();
            repository = new PrescriptionRepository(db);

        }
        public void Dispose()
        {
            using (var context = GetInMemoryContext())
            {
                context.Database.EnsureDeleted();
            }
        }
        private MainDataContext GetInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<MainDataContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;
            return new MainDataContext(options);

        }
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task PrescriptionRepository_Should_GetAllPerscriptionsForUser(int userId)
        {
            var perscriptionList = repository.GetAllPerscirptionsForUser(userId);
            foreach (var perscription in perscriptionList)
            {
                Assert.Equal(userId, perscription.patientId);
            }
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task PrescriptionRepository_Should_GetPerscriptionById(int perscriptionId)
        {
          
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task PrescriptionRepository_Should_ReturnPerscriptionsPaginated_By_Doctor(int doctorId)
        {
           
        }
    }
}