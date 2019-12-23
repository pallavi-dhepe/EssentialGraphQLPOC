using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashboardBackend.DataAccess.Contracts;
using DashboardBackend.Database;
using DashboardBackend.Database.Models;

namespace DashboardBackend.DataAccess.Repositories
{
    /// <summary>
    /// todo
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly DashboardDBContext _DashboardDBContext;

        public PersonRepository(DashboardDBContext DashboardDBContext)
        {
            _DashboardDBContext = DashboardDBContext;
        }

        public async Task<Person> Add(Person person)
        {
            await _DashboardDBContext.Person.AddAsync(person);
            await _DashboardDBContext.SaveChangesAsync();
            return person;
        }

        public async Task<Person> GetById(int id)
        {
            return await _DashboardDBContext.Person?.FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public async Task<List<Person>> GetAll()
        {
            return await _DashboardDBContext.Person?.ToListAsync();
        }

        public async Task<List<Person>> GetByProjectId(int projectid)
        {
            return await _DashboardDBContext.Person.Where(x => x.ProjectId == projectid)?.ToListAsync();
        }

        public async Task<List<Person>> GetByProjectIdAndRole(int projectid, int roleid)
        {
            return await _DashboardDBContext.Person.Where(x => x.ProjectId == projectid && x.RoleId == roleid)?.ToListAsync();
        }
    }
}
