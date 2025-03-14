using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project?> GetProjectById(int projectId)
        {
            return await _context.Projects.Include(x => x.StepList).FirstOrDefaultAsync(x => x.Id == projectId);
        }

        public async Task<List<Project>> GetActiveProjects()
        {
            return await _context.Projects.Where(x=> x.IsActive == true).OrderByDescending(x=>x.DueDate).ToListAsync();
        }

        public async Task AddStepToProject(Step step, int projectId)
        {
            var project = await GetProjectById(projectId);
            var position = project.StepList.Select(x => x.Position).Max() + 1;
            step.Position = position;

            project.StepList.Add(step);
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
