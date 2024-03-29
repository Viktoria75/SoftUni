﻿using ItKarieraProjectTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ItKarieraProjectTest.DAO
{
    public class ProfileDAO : IProfileDAO
    {
		//personinfo = users
		//workersprofile = logins


		public PersonInfo LogIn(string username, string password)
		{
			var user = this.context.WorkersProfile
				.Include(l => l.PersonInfo)
				.Where(u => u.Username.Equals(username) && u.Password.Equals(password))
				.FirstOrDefault()?.PersonInfo;

			return user;
		}

		public void RegisterUser(PersonInfo loginInfo)
		{
			this.context.PersonInfo.Add(loginInfo);
			this.context.SaveChanges();

		}

		private SoftUniProjectDBContext context;
		public ProfileDAO(SoftUniProjectDBContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			this.context = context;
		}

	}
}
