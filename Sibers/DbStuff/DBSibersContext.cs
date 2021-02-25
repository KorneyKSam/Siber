using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.DbStuff
{
    public class DBSibersContext : DbContext
    {
        public DBSibersContext(DbContextOptions dbContext) : base(dbContext) { }
    }
}
