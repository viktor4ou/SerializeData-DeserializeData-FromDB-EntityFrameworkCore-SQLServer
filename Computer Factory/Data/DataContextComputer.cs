using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computer_Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Computer_Factory.Data
{
    public class DataContextComputer : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        private IConfiguration _config;
        public DataContextComputer(IConfiguration config)
        {   
                _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString, optionsBuilder => optionsBuilder.EnableRetryOnFailure());
        }
    }
}
