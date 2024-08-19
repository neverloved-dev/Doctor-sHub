using System.Collections.Generic;
using System.Linq;
using Main.DTOs;
using Main.Models;
using Main.Repositories;
using Main.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class DoctorServiceTests : IDisposable
{
    private DbContextOptions<MainContext> CreateNewContextOptions()
    {
        return new DbContextOptionsBuilder<MainContext>()
            .UseInMemoryDatabase(databaseName: "DoctorServiceDatabase")
            .Options;
    }

    [Fact]
    public void GetSingleDoctor_ShouldReturnDoctorDTO_WhenDoctorExists()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var doctor = new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 };
            context.Doctors.Add(doctor);
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            var service = new DoctorService(repository);

            var result = service.GetSingleDoctor(1);

            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("Cardiology", result.Speciality);
            Assert.Equal(10, result.YearsOfExperience);
        }
    }

    [Fact]
    public void GetSingleDoctor_ShouldReturnNull_WhenDoctorDoesNotExist()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var repository = new DoctorRepository(context);
            var service = new DoctorService(repository);

            var result = service.GetSingleDoctor(1);

            Assert.Null(result);
        }
    }

    [Fact]
    public void UpdateDoctor_ShouldReturnUpdatedDoctorDTO()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var doctor = new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 };
            context.Doctors.Add(doctor);
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            var service = new DoctorService(repository);

            var updatedDoctor = new Doctor { Id = 1, Name = "Johnny", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 15 };

            var result = service.UpdateDoctor(updatedDoctor);

            Assert.NotNull(result);
            Assert.Equal("Johnny", result.Name);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("Cardiology", result.Speciality);
            Assert.Equal(15, result.YearsOfExperience);
        }
    }

    [Fact]
    public void AddNewDoctor_ShouldCreateNewDoctor()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var repository = new DoctorRepository(context);
            var service = new DoctorService(repository);

            var requestDto = new CreateDoctorDTO
            {
                Name = "John",
                LastName = "Doe",
                Specialization = "Cardiology",
                YearsOfExperience = 10
            };

            service.AddNewDoctor(requestDto);

            var doctor = context.Doctors.SingleOrDefault(d => d.Name == "John");

            Assert.NotNull(doctor);
            Assert.Equal("Doe", doctor.LastName);
            Assert.Equal("Cardiology", doctor.Specialization);
            Assert.Equal(10, doctor.YearsOfExperience);
        }
    }

    [Fact]
    public void GetDoctorsPaginated_ShouldReturnPaginatedDoctorDTOs()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            context.Doctors.AddRange(
                new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 },
                new Doctor { Id = 2, Name = "Jane", LastName = "Doe", Specialization = "Neurology", YearsOfExperience = 8 },
                new Doctor { Id = 3, Name = "Jim", LastName = "Beam", Specialization = "Oncology", YearsOfExperience = 5 }
            );
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            var service = new DoctorService(repository);

            var result = service.GetDoctorsPaginated(0, 2);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].Name);
            Assert.Equal("Jane", result[1].Name);
        }
    }

    [Fact]
    public void DeleteDoctor_ShouldRemoveDoctor()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var doctor = new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 };
            context.Doctors.Add(doctor);
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            var service = new DoctorService(repository);

            service.DeleteDoctor(1);

            var deletedDoctor = context.Doctors.SingleOrDefault(d => d.Id == 1);

            Assert.Null(deletedDoctor);
        }
    }

    public void Dispose()
    {
         var options = CreateNewContextOptions();
         using(var context = new MainContext(options))
         {
             context.Database.EnsureDeleted();
         }
    }
}
