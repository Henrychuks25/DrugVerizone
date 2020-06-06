﻿using DrugVerizone.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugVerizone.Models;

namespace DrugVerizone.DbContexts
{
    public class DrugVerifyContext : DbContext
    {

        public DrugVerifyContext(DbContextOptions<DrugVerifyContext> options):base(options)
        {

        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Pins> Pins { get; set; }
        public virtual DbSet<Drugs> Drugs { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<DrugVerizone.Models.DrugCreateDto> DrugCreateDto { get; set; }
    }
}
