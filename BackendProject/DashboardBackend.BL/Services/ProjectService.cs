using DashboardBackend.BL.Interfaces;
using DashboardBackend.DataAccess.Contracts;
using DashboardBackend.Database.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashboardBackend.BL.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository;
        private IConfiguration _configuration;
        private IQueueClient _queueClient;

        public ProjectService(IProjectRepository projectRepository, IConfiguration Configuration)
        {
            _projectRepository = projectRepository;
            _configuration = Configuration;
        }
        public async Task<List<Project>> GetAllProjects()
        {
            return await _projectRepository.GetAll();
        }

        public async Task<Project> GetProject(int projectId)
        {
           var project = await _projectRepository.Get(projectId);

            //connect to service bus and inform project is accessed 
           await SendMessage(project, _configuration["ServiceBus:Connection"], _configuration["ServiceBus:QueueName"]);

           return project;
        }
        private async Task SendMessage(Project project, string serviceBusConnectionString, string queueName)
        {
            _queueClient = new QueueClient(serviceBusConnectionString, queueName);
            var messageBody = $"Project accessed, ProjectName: {project.ProjectName}";
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            await _queueClient.SendAsync(message);
            await _queueClient.CloseAsync();
        }      
    }
}
