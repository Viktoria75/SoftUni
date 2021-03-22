using System;
using ItKarieraProjectTest.CustomExceptions;
using ItKarieraProjectTest.DAO;
using ItKarieraProjectTest.Models;
using ItKarieraProjectTest.Presentation.Utility;

namespace ItKarieraProjectTest.Presentation
{
    public class LoginController : ILoginController
	{

		public int Login(string username, string password)
		{
			PersonInfo user = this.profileDAO.LogIn(username, password);
			if (user == null)
				throw new IncorrectCredentialsException("Incorrect credentials");
			Session.CurrentUser = user;
			return user.Id;
		}


		public void Register(RegistrationViewModel registrationViewModel)
		{
			PersonInfo user = new PersonInfo();
			user.FirstName = registrationViewModel.FirstName;
			user.LastName = registrationViewModel.LastName;
			user.CompanyId = registrationViewModel.Company;
			user.WorkHours = registrationViewModel.WorkHours;
			user.Money = registrationViewModel.Balance;


			WorkersProfile loginInfo = new WorkersProfile();
			loginInfo.Username = registrationViewModel.Username;
			loginInfo.Password = registrationViewModel.Password;
			loginInfo.PersonInfo = user;

			this.profileDAO.RegisterUser(loginInfo);
		}

		private IProfileDAO profileDAO = null;

		public LoginController(IProfileDAO profileDAO)
		{
			this.profileDAO = profileDAO;
		}
	}
}
