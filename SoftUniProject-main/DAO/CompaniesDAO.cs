using System;
using System.Linq;
using ItKarieraProjectTest.Models;

namespace ItKarieraProjectTest.DAO
{
	//Assigns the value to a database value
	public class CompaniesDAO : ICompaniesDAO
    {
		public PersonInfo GetCompany(int id)
		{
			return this.context.PersonInfo.Where(r => r.CompanyId.Equals(id)).FirstOrDefault();
		}

		private SoftUniProjectDBContext context;
		public CompaniesDAO(SoftUniProjectDBContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			this.context = context;
		}
	}
}
