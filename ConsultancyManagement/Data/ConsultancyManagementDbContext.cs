using Microsoft.EntityFrameworkCore;
using ConsultancyManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Data
{
    public class ConsultancyManagementDbContext : DbContext
    {
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }


        public ConsultancyManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMaster>()
                .HasOne(s => s.Role)
                .WithMany().HasForeignKey(x => x.RoleId);
        }
    }
}
