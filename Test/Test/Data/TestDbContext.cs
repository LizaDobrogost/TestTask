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
        public DbSet<AddressModel> AddressModels { get; set; }
        public DbSet<AreasModel> AreasModels { get; set; }
        public DbSet<ContactInfoModel> ContactInfoModels { get; set; }
        public TestDbContext(DbContextOptions<TestDbContext> options):
            base(options)
        {
        }
    }
}
