using System;
using System.Linq;
using ItKarieraProjectTest.Models;

namespace ItKarieraProjectTest.DAO
{
    public class WorkHoursDAO: IWorkHoursDAO
	{
		public PersonInfo GetHours(int workhours)
		{
			return this.context.PersonInfo.Where(r => r.WorkHours.Equals(workhours)).FirstOrDefault();
		}

		private SoftUniProjectDBContext context;
		public WorkHoursDAO(SoftUniProjectDBContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			this.context = context;
		}
	}
}
