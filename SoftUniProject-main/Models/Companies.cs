using System;
using System.Collections.Generic;

namespace ItKarieraProjectTest.Models
{
    public partial class Companies
    {
        public Companies()
        {
            PersonInfo = new HashSet<PersonInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }

        public virtual ICollection<PersonInfo> PersonInfo { get; set; }
    }
}
