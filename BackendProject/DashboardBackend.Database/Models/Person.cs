using System;
using System.Collections.Generic;
using System.Text;

namespace DashboardBackend.Database.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string EmailAddress { get; set; }

        public int RoleId { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
