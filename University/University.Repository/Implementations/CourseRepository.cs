﻿using Microsoft.EntityFrameworkCore;
using University.Models.Entities;
using University.Repository.Data;
using University.Repository.Interfaces;

namespace University.Repository.Implementations
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Save() => await _context.SaveChangesAsync();


        public async Task Update(Course entity)
        {
            var entityFromDb = await _context.Courses.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb is not null)
            {
                entityFromDb.Title = entity.Title;
                entityFromDb.TeacherId = entity.TeacherId;
            }
        }
    }
}
