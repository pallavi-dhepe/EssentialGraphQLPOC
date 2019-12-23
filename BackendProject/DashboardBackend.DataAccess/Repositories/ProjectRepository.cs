using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashboardBackend.DataAccess.Contracts;
using DashboardBackend.Database;
using DashboardBackend.Database.Models;

namespace DashboardBackend.DataAccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DashboardDBContext _DashboardDBContext;

        public ProjectRepository(DashboardDBContext DashboardDBContext)
        {
            _DashboardDBContext = DashboardDBContext;
        }

        public async Task<Project> Add(Project project)
        {
            await _DashboardDBContext.Project.AddAsync(project);
            await _DashboardDBContext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> Get(int id)
        {
            return await _DashboardDBContext.Project?.FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task<List<Project>> GetAll()
        {
            return await _DashboardDBContext.Project?.ToListAsync();
        }
    }
}
