using System;
using System.Linq;
using ItKarieraProjectTest.Models;

namespace ItKarieraProjectTest.DAO
{
	//Assigns the value to a database value
	public class BalanceDAO : IBalanceDAO
    {
		public PersonInfo GetBalance(decimal money)
		{
			return this.context.PersonInfo.Where(r => r.Money.Equals(money)).FirstOrDefault();
		}

		private SoftUniProjectDBContext context;
		public BalanceDAO(SoftUniProjectDBContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			this.context = context;
		}
	}
}
