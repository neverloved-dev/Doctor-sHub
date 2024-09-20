using Main.DTOs;
using Main.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Main.Repositories;

public class DoctorRepository
{
    private MainContext _context;

    public DoctorRepository(MainContext context)
    {
        _context = context;
    }
    public void Create(Doctor variable)
    {
        _context.Doctors.Add(variable);
        _context.SaveChanges();
    }

    public void Delete(int doctorId)
    {
        var doctorToRemove = _context.Doctors.Find(doctorId);
        if (doctorToRemove == null) return;
        _context.Doctors.Remove(doctorToRemove);
        _context.SaveChanges();
    }

    public List<Doctor> GetAll()
    {
        return _context.Doctors.ToList();
    }

    public Doctor? GetSingle(int id)
    {
        var doctor = _context.Doctors.Find(id);
        return doctor ?? null;
    }

    public Doctor Update(Doctor update)
    {
        var doctorToUpdate = _context.Doctors.Find(update.Id);
        if (doctorToUpdate == null) return null;
        doctorToUpdate.Name = update.Name;
        doctorToUpdate.LastName = update.LastName;
        doctorToUpdate.Specialization = update.Specialization;
        doctorToUpdate.YearsOfExperience = update.YearsOfExperience;
        _context.SaveChanges();

        return doctorToUpdate;
    }

    public List<Doctor>? GetDoctorPaginated(int pageNumber, int pageSize)
    {
        IQueryable<Doctor> query = _context.Doctors;
        int skipAmount = pageNumber * pageSize;

        return query.Skip(skipAmount)
            .Take(pageSize)
            .ToList();
        
    }
    
    
}