using System;
using ItKarieraProjectTest.DAO;
using ItKarieraProjectTest.Models;
using ItKarieraProjectTest.Presentation.Utility;

namespace ItKarieraProjectTest.Presentation
{
    public class LoginController : ILoginController
	{
		//personinfo = users
		//workersprofile = logins

		public int Login(string username, string password)
		{
			PersonInfo user = this.profileDAO.LogIn(username, password);
			if (user == null)
				throw new Exception("Incorrect credentials");
			Session.CurrentUser = user;
			return user.Id;
		}


		public void Register(RegistrationViewModel registrationViewModel)
		{
			PersonInfo user = new PersonInfo();
			user.FirstName = registrationViewModel.FirstName;
			user.LastName = registrationViewModel.LastName;
			user.CompanyId = this.companiesDAO.GetCompany(registrationViewModel.Company).CompanyId;
			user.WorkHours = this.workhoursDAO.GetHours(registrationViewModel.WorkHours).WorkHours;//problem
			user.Money = this.balanceDAO.GetBalance(registrationViewModel.Balance).Money;

			WorkersProfile loginInfo = new WorkersProfile();
			loginInfo.Username = registrationViewModel.Username;
			loginInfo.Password = registrationViewModel.Password;
			loginInfo.PersonInfo = user;

			this.profileDAO.RegisterUser(loginInfo);
		}

		private IProfileDAO profileDAO = null;
		private ICompaniesDAO companiesDAO = null;
		private IWorkHoursDAO workhoursDAO = null;
		private IBalanceDAO balanceDAO = null;
		public LoginController(IProfileDAO profileDAO, ICompaniesDAO companiesDAO, IWorkHoursDAO workhoursDAO, IBalanceDAO balanceDAO)
		{
			this.profileDAO = profileDAO;
			this.companiesDAO = companiesDAO;
			this.workhoursDAO = workhoursDAO;
			this.balanceDAO = balanceDAO;
		}
	}
}
