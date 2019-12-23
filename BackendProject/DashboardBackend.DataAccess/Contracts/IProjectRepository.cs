using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DashboardBackend.Database.Models;

namespace DashboardBackend.DataAccess.Contracts
{
    public interface IProjectRepository
    {
        Task<Project> Get(int id);
        Task<List<Project>> GetAll();
        Task<Project> Add(Project project);
    }
}
