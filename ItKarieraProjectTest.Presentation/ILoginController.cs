using System;
using System.Collections.Generic;
using System.Text;

namespace ItKarieraProjectTest.Presentation
{
    public interface ILoginController
    {
        int Login(string username, string password);
        void Register(RegistrationViewModel registrationViewModel);
    }
}
