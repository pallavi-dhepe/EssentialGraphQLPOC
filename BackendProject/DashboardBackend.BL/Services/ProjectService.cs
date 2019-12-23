using System.Collections.Generic;
using System.Threading.Tasks;
using DashboardBackend.BL.Interfaces;
using DashboardBackend.DataAccess.Contracts;
using DashboardBackend.Database.Models;

namespace DashboardBackend.BL.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<List<Project>> GetAllProjects()
        {
            return await _projectRepository.GetAll();
        }

        public async Task<Project> GetProject(int projectId)
        {
            return await _projectRepository.Get(projectId);
        }
    }
}
