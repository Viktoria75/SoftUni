using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using ItKarieraProjectTest.DAO;

namespace ItKarieraProjectTest.Presentation
{
	//AutoFAQ
	public static class ContainerConfig
	{
		public static IContainer Configure()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<LoginForm>().SingleInstance();
			builder.RegisterType<RegisterForm>();
			builder.RegisterType<MainMenu>();
			builder.RegisterType<ProfileDAO>().As<IProfileDAO>();
			builder.RegisterType<WorkHoursDAO>().As<IWorkHoursDAO>();
			builder.RegisterType<CompaniesDAO>().As<ICompaniesDAO>();
			builder.RegisterType<BalanceDAO>().As<IBalanceDAO>();
			builder.RegisterType<LoginController>().As<ILoginController>();

			builder.RegisterInstance<SoftUniProjectDBContext>(new SoftUniProjectDBContext());

			return builder.Build();
		}
	}
}
