using System;
using System.Linq;
using ItKarieraProjectTest.Models;

namespace ItKarieraProjectTest.DAO
{
	//Assigns the value to a database value
	public class RateDAO:IRateDAO
    {
		public Companies GetRate(int rate)
		{
			return this.context.Companies.Where(r => r.Rate.Equals(rate)).FirstOrDefault();
		}

		private SoftUniProjectDBContext context;
		public RateDAO(SoftUniProjectDBContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			this.context = context;
		}
	}
}
