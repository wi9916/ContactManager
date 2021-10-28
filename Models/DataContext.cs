﻿using ContactManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }
    }
}
