using System;
using System.Collections.Generic;
using System.Text;

namespace ItKarieraProjectTest.CustomExceptions
{
    public class IncorrectCredentialsException : Exception
    {
        public IncorrectCredentialsException(string message)
            : base(message)
        {

        }
    }
}
