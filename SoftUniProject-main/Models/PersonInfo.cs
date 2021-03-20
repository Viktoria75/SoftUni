using System;
using System.Collections.Generic;

namespace ItKarieraProjectTest.Models
{
    public partial class PersonInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Money { get; set; }
        public int CompanyId { get; set; }
        public int WorkHours { get; set; }

        public virtual Companies Company { get; set; }
        public virtual WorkersProfile IdNavigation { get; set; }
    }
}
