using HelathProject_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthProject_Domain
{
    public class HealthProjectDbEntities : DbContext
    {
        public HealthProjectDbEntities(DbContextOptions<HealthProjectDbEntities> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Status> Statuses { get; set; }


    }
}
