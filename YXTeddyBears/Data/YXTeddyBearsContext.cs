using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YXTeddyBears.Models;

namespace YXTeddyBears.Data
{
    public class YXTeddyBearsContext : DbContext
    {
        public YXTeddyBearsContext (DbContextOptions<YXTeddyBearsContext> options)
            : base(options)
        {
        }

        public DbSet<YXTeddyBears.Models.TeddyBears> TeddyBears { get; set; }
    }
}
