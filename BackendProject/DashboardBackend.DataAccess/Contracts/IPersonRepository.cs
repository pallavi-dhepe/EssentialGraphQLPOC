using DashboardBackend.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashboardBackend.DataAccess.Contracts
{
    public interface IPersonRepository
    {
        Task<Person> GetById(int id);
        Task<List<Person>> GetAll();
        Task<Person> Add(Person person);

        Task<List<Person>> GetByProjectId(int projectid);

        Task<List<Person>> GetByProjectIdAndRole(int projectid, int roleid);
    }
}
