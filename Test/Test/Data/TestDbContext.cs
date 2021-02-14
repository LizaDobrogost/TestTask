using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Models;


namespace Test.Data
{
    public class TestDbContext:DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public TestDbContext(DbContextOptions<TestDbContext> options):
            base(options)
        {
        }
    }
}
