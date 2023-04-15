using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Entity.Entities;

namespace Sat.Recruitment.Infrastructure.Data
{
    public class SatRecruitmentContext : DbContext
	{
		public DbSet<User> Users => Set<User>();

		public SatRecruitmentContext(DbContextOptions<SatRecruitmentContext> options) : base(options) { }
	}
}
