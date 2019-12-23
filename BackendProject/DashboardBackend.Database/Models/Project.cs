using System.Collections.Generic;

namespace DashboardBackend.Database.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public bool IsActive { get; set; }

        public bool? IsTechDashBoardApplicable { get; set; }

        public bool? IsQADashBoardApplicable { get; set; }

        public string TestingScope { get; set; }

        public IList<Person> Persons { get; set; }
    }
}
