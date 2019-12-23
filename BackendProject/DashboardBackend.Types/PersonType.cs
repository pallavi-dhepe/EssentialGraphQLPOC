using GraphQL.Types;
using DashboardBackend.Database.Models;

namespace DashboardBackend.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.PersonId);
            Field(x => x.PersonName);
            Field(x => x.RoleId);
            Field(x => x.EmailAddress, nullable: true);           
        }
    }
}
