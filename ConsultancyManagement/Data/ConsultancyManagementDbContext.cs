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
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CompanyMaster> CompanyMasters { get; set; }
        public DbSet<JobMaster> JobMasters { get; set; }
        public DbSet<SkillMaster> SkillMasters { get; set; }


        public ConsultancyManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMaster>()
                .HasOne(s => s.Role)
                .WithMany().HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<RoleMaster>().HasData(
                   new RoleMaster { Id = Convert.ToInt32(RoleEnum.Admin), Name = RoleEnum.Admin.ToString() },
                   new RoleMaster { Id = Convert.ToInt32(RoleEnum.HR), Name = RoleEnum.HR.ToString() },
                   new RoleMaster { Id = Convert.ToInt32(RoleEnum.JobSeeker), Name = RoleEnum.JobSeeker.ToString() }
                   );

            modelBuilder.Entity<Department>().HasData(
                    new Department { Id = 1, Name = "Admin" },
                    new Department { Id = 2, Name = "HR" },
                    new Department { Id = 3, Name = "IT" }
                );

            modelBuilder.Entity<Designation>().HasData(
               new Designation { Id = 1, Name = "Software Engineer" },
               new Designation { Id = 2, Name = "Senior Software Engineer" }
               );
        }
    }
}
