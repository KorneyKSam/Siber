using Sibers.DbStuff.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sibers.DbStuff.Repository
{
    public class Employee_Project_Repository
    {
        protected DBSibersContext _context;
        protected DbSet<EmployeeProject> _dbSet;

        public Employee_Project_Repository(DBSibersContext context)
        {
            _context = context;
            _dbSet = context.Set<EmployeeProject>();
        }

        public IEnumerable<EmployeeProject> GetAllProjectsOfEmployee(long employeeId)
        {
            return _dbSet.Where(x => x.EmployeeId == employeeId).Include(project => project.Project);
        }

        public IEnumerable<EmployeeProject> GetAllEmployeesFromTheProject(long projectId)
        {
            return _dbSet.Where(x => x.ProjectId == projectId).Include(e => e.Employee).Include(p => p.Project).ToList();
        }

        public IEnumerable<Employee> GetAllEmployeesOutsideTheProject(long projectId)
        {
            return _context.Employees
                .ToList()
                .Where(emp => 
                !GetAllEmployeesFromTheProject(projectId)
                .Select(x => x.Employee)
                .Select(emp2 => emp2.Id)
                .Contains(emp.Id))
                .ToList();
        }

        public void Save(EmployeeProject model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
        }

        public void Delete(long employeeId, long projectId)
        {
            var model = Get(employeeId, projectId);
            _dbSet.Remove(model);
            _context.SaveChanges();
        }

        public void Add(EmployeeProject model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
        }

        public EmployeeProject Get(long employeeId, long projectId)
        {
            return _dbSet.SingleOrDefault(x => x.EmployeeId == employeeId && x.ProjectId == projectId);
        }


    }
}
