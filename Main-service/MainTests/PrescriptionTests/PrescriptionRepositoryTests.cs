
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainTests
{
    public class PrescriptionRepositoryTests
    {
        

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task PrescriptionRepository_Should_GetAllPerscriptionsForUser(int userId)
        {

        }
        [Theory]
        [InlineData("")]
        [InlineData("")]
        [InlineData("")]
        [InlineData("")]
        public async Task PrescriptionRepository_Should_GetPerscriptionById(string perscriptionId)
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