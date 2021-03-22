using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace ItKarieraProjectTest.Presentation.Utility
{
    //Creates the Form
    class FormFactory
    {
        public static ILifetimeScope _scope;

        public static T GetFormInstance<T>()
        {
            return _scope is null ? throw new ArgumentException("scope") : _scope.Resolve<T>();
        }
    }
}
