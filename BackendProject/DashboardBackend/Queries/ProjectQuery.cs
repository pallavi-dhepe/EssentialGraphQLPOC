using DashboardBackend.BL.Interfaces;
using DashboardBackend.Types;
using GraphQL.Types;

namespace DashboardBackend.Queries
{
    public class ProjectQuery : ObjectGraphType
    {
        public ProjectQuery(IProjectService projectService) 
        {
            Field<ListGraphType<ProjectType>>(
                "projects",
                resolve: context => projectService.GetAllProjects());

            Field<ProjectType>(
               "project",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "projectid" }),
               resolve: context => projectService.GetProject(context.GetArgument<int>("projectid")));          
          
        }
    }
}
