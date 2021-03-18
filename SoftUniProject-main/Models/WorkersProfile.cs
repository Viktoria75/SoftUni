using System;
using System.Collections.Generic;

namespace ItKarieraProjectTest.Models
{
    public partial class WorkersProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual PersonInfo PersonInfo { get; set; }
    }
}
