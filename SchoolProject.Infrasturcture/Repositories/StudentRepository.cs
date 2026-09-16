using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Infrasturcture.Context;

namespace SchoolProject.Infrasturcture.Repositories;

public class StudentRepository(ApplicationDbContext context) : IStudentRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.Include(x => x.Department).ToListAsync();
    }
}
