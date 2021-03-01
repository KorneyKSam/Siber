using Sibers.DbStuff.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sibers.DbStuff.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(DBSibersContext context) : base(context) { }

        public override List<Employee> GetAll()
        {
            return _dbSet.Include(employee => employee.CustomerCompany).ToList();
        }
    }
}
