using DashboardBackend.Database.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace DashboardBackend.BL.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProject(int projectId);
    }
}
