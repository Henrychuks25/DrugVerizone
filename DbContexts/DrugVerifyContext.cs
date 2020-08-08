using DrugVerizone.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugVerizone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DrugVerizone.DbContexts
{
    public class DrugVerifyContext : IdentityDbContext<ApplicationUser>
    {

        public DrugVerifyContext(DbContextOptions<DrugVerifyContext> options):base(options)
        {

        }

        public virtual DbSet<Admin> Admins { get; set; }
        //public virtual DbSet<Roles> Roles { get; set; }
      
        public virtual DbSet<Drugs> Drugs { get; set; }
        public virtual DbSet<Complaints> Complaint { get; set; }
        public virtual DbSet<DrugTypes> DrugType { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        
    }
}
