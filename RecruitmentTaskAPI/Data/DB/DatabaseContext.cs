using Microsoft.EntityFrameworkCore;
using RecruitmentTaskAPI.Data.DB.Model;
using RecruitmentTaskAPI.Utils;

namespace RecruitmentTaskAPI.Data.DB
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EmailModel> Emails { get; set; }
        public DbSet<AttributeData> Attributes { get; set; }
        public DbSet<EmailAttribute> EmailAttributes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.DBConnectionString);
        }
    }
}
