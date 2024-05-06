using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //TODO: Implement CRUD operations with pagination using DoctorRepository
    }
}