using Sibers.DbStuff.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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
            var project = _context.Projects.SingleOrDefault(x => x.Id == projectId);
            var employeeOnProject = GetAllEmployeesFromTheProject(projectId).Select(x => x.Employee).ToList();
            var result = _context.Employees.ToList();
            result.RemoveAll(emp1 => employeeOnProject.Exists(emp2 => emp2.Id == emp1.Id));
            result.RemoveAll(x => x.Company != project.ExecutingCompanyId);
            return result;

        }

        public string Save(EmployeeProject model)
        {
            try
            {
                _dbSet.Add(model);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return "Success";
        }

        public string Delete(long employeeId, long projectId)
        {
            try
            {
                var model = Get(employeeId, projectId);
                _dbSet.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return "Success";
        }

        public string Add(EmployeeProject model)
        {
            try
            {
                var employeeCompany = _context.Employees.Find(model.EmployeeId).Company;
                var projectCompany = _context.Projects.Find(model.ProjectId).ExecutingCompanyId;
                if (employeeCompany != projectCompany)
                    throw new Exception("Для выполнения задачи сотрудник должен работать на компанию");

                _dbSet.Add(model);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return "Success";
        }

        public EmployeeProject Get(long employeeId, long projectId)
        {
            return _dbSet.SingleOrDefault(x => x.EmployeeId == employeeId && x.ProjectId == projectId);
        }


    }
}
