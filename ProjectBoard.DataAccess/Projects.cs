﻿using Microsoft.EntityFrameworkCore;
using ProjectBoard.Model;

namespace ProjectBoard.DataAccess
{
    public class Projects
    {
        private readonly ProjectDbContext _context;
        public Projects(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<List<Project>> GetAllProjects()
        {
            return await _context.Projects.Include(a => a.StepList).ToListAsync();
        }
    }
}