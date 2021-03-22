using ItKarieraProjectTest.DAO;
using ItKarieraProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItKarieraProject.Test.Dummies
{
	//DummyDAO
	class ProfileDAODummy : IProfileDAO
    {
		private string username = "testUser";
		private string password = "1234";
		public PersonInfo LogIn(string username, string password)
		{
			if (this.username.Equals(username) && this.password.Equals(password))
			{
				return CreateDummyUser();
			}

			return null;
		}

		private PersonInfo CreateDummyUser()
		{
			PersonInfo user = new PersonInfo();
			user.Id = 0;

			return user;
		}

		public void RegisterUser(WorkersProfile loginInfo)
		{
			throw new System.NotImplementedException();
		}
	}
}
