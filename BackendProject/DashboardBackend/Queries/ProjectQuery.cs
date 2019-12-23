using GraphQL.Types;
using DashboardBackend.DataAccess.Contracts;
using DashboardBackend.Types;

namespace DashboardBackend.Queries
{
    public class ProjectQuery : ObjectGraphType
    {
        public ProjectQuery(IProjectRepository projectRepository)
        {
            Field<ListGraphType<ProjectType>>(
                "projects",
                resolve: context => projectRepository.GetAll());

            Field<ProjectType>(
               "project",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "projectid" }),
               resolve: context => projectRepository.Get(context.GetArgument<int>("projectid")));
           
          
        }
    }
}
