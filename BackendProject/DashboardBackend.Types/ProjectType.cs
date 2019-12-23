using GraphQL.Types;
using DashboardBackend.DataAccess.Contracts;
using DashboardBackend.Database.Models;

namespace DashboardBackend.Types
{
    public class ProjectType : ObjectGraphType<Project>
    {
        public ProjectType(IPersonRepository personRepository)
        {
            Field(x => x.ProjectId);
            Field(x => x.ProjectName);
            Field(x => x.IsActive);
            Field(x => x.IsTechDashBoardApplicable, nullable: true);
            Field(x => x.IsQADashBoardApplicable, nullable: true);
            Field(x => x.TestingScope);
            Field<ListGraphType<PersonType>>("persons", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "roleid"}),
                 resolve: context => {
                     var roleIdFilter = context.GetArgument<int?>("roleid");
                     return roleIdFilter != null
                            ? personRepository.GetByProjectIdAndRole(context.Source.ProjectId, roleIdFilter.Value)
                            : personRepository.GetByProjectId(context.Source.ProjectId);
                   }, 
                 description: "People in the project");
        }
    }
}
