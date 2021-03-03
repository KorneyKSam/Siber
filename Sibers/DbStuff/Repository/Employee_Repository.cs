using Sibers.DbStuff.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sibers.DbStuff.Repository
{
    public class Employee_Repository : Base_Repository<Employee>
    {
        public Employee_Repository(DBSibersContext context) : base(context) { }

        public override List<Employee> GetAll()
        {
            return _dbSet.Include(employee => employee.CustomerCompany).ToList();
        }

        public string GetFullName(long id) 
        {
            var employee = _dbSet.SingleOrDefault(x => x.Id == id);
            return $"{employee.LastName} {employee.FirstName} {employee.MiddleName}";
        }

    }
}
