using System.Collections.Generic;
using System.Linq;
using Main.Models;
using Main.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class DoctorRepositoryTests : IDisposable
{
    private DbContextOptions<MainContext> CreateNewContextOptions()
    {
        return new DbContextOptionsBuilder<MainContext>()
            .UseInMemoryDatabase(databaseName: "DoctorDatabase")
            .Options;
    }

    [Fact]
    public void Create_ShouldAddDoctor()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var repository = new DoctorRepository(context);
            var doctor = new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 };

            repository.Create(doctor);
        }

        using (var context = new MainContext(options))
        {
            Assert.Equal(1, context.Doctors.Count());
            Assert.Equal("John", context.Doctors.Single().Name);
        }
    }

    [Fact]
    public void Delete_ShouldRemoveDoctor_WhenDoctorExists()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var doctor = new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 };
            context.Doctors.Add(doctor);
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            repository.Delete(doctor.Id);
        }

        using (var context = new MainContext(options))
        {
            Assert.Equal(0, context.Doctors.Count());
        }
    }

    [Fact]
    public void Delete_ShouldNotRemoveDoctor_WhenDoctorDoesNotExist()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var repository = new DoctorRepository(context);
            repository.Delete(1);
        }

        using (var context = new MainContext(options))
        {
            Assert.Equal(0, context.Doctors.Count());
        }
    }

    [Fact]
    public void GetAll_ShouldReturnAllDoctors()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            context.Doctors.Add(new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 });
            context.Doctors.Add(new Doctor { Id = 2, Name = "Jane", LastName = "Doe", Specialization = "Neurology", YearsOfExperience = 8 });
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            var result = repository.GetAll();

            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].Name);
            Assert.Equal("Jane", result[1].Name);
        }
    }

    [Fact]
    public void GetSingle_ShouldReturnDoctor_WhenDoctorExists()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var doctor = new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 };
            context.Doctors.Add(doctor);
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            var result = repository.GetSingle(doctor.Id);

            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
        }
    }

    [Fact]
    public void GetSingle_ShouldReturnNull_WhenDoctorDoesNotExist()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var repository = new DoctorRepository(context);
            var result = repository.GetSingle(1);

            Assert.Null(result);
        }
    }

    [Fact]
    public void Update_ShouldModifyDoctor_WhenDoctorExists()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var doctor = new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 };
            context.Doctors.Add(doctor);
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            var updatedDoctor = new Doctor { Id = 1, Name = "Johnny", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 15 };

            var result = repository.Update(updatedDoctor);

            Assert.NotNull(result);
            Assert.Equal("Johnny", result.Name);
            Assert.Equal(15, result.YearsOfExperience);
        }
    }

    [Fact]
    public void Update_ShouldReturnNull_WhenDoctorDoesNotExist()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            var repository = new DoctorRepository(context);
            var updatedDoctor = new Doctor { Id = 1, Name = "Johnny", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 15 };

            var result = repository.Update(updatedDoctor);

            Assert.Null(result);
        }
    }

    [Fact]
    public void GetDoctorPaginated_ShouldReturnDoctorsInPage()
    {
        var options = CreateNewContextOptions();

        using (var context = new MainContext(options))
        {
            context.Doctors.AddRange(
                new Doctor { Id = 1, Name = "John", LastName = "Doe", Specialization = "Cardiology", YearsOfExperience = 10 },
                new Doctor { Id = 2, Name = "Jane", LastName = "Doe", Specialization = "Neurology", YearsOfExperience = 8 },
                new Doctor { Id = 3, Name = "Jim", LastName = "Beam", Specialization = "Oncology", YearsOfExperience = 5 },
                new Doctor { Id = 4, Name = "Jack", LastName = "Daniels", Specialization = "Pediatrics", YearsOfExperience = 3 }
            );
            context.SaveChanges();

            var repository = new DoctorRepository(context);
            var result = repository.GetDoctorPaginated(0, 2);

            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].Name);
            Assert.Equal("Jane", result[1].Name);
        }
    }

    public void Dispose()
    {
        var options = CreateNewContextOptions();
        using (var context = new MainContext(options))
        {
            context.Database.EnsureDeleted();  
        }
    }
}
