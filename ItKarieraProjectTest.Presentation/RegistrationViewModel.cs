using System;
using System.Collections.Generic;
using System.Text;

namespace ItKarieraProjectTest.Presentation
{

    public class RegistrationViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Company{ get; set; }
        public int WorkHours { get; set; }
        public decimal Balance { get; set; }
    }
}
