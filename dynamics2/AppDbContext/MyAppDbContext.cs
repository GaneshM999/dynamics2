using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using dynamics2.Models;

namespace dynamics2.AppDbContext
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext() : base("name=sqlconnection")
        {

        }
        public DbSet <Department> Departments { get; set; }
        public DbSet<Employee>Employees { get; set; }
    }
}