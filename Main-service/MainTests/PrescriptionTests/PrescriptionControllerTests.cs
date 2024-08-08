using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;

namespace MainTests.PrescriptionTests
{
    public class PrescriptionControllerTests:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;

        public PrescriptionControllerTests(WebApplicationFactory<Program> client)
        {
            _applicationFactory = client;
        }
    }
}