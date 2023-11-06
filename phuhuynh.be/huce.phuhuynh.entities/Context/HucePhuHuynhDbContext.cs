using huce.phuhuynh.entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huce.phuhuynh.entities.Context
{
    public class HucePhuHuynhDbContext : DbContext
    {
        public HucePhuHuynhDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
    }
}
