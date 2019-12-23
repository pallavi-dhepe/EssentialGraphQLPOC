using GraphQL;
using DashboardBackend.Queries;

namespace DashboardBackend.Schemas
{
    public class DashboardDBContextSchema : GraphQL.Types.Schema
    {
        public DashboardDBContextSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<ProjectQuery>();
            //Mutation = resolver.Resolve<ProjectMutation>();
        }
       
    }
}
