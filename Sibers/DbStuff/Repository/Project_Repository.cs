using Microsoft.EntityFrameworkCore;
using Sibers.DbStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class Project_Repository : Base_Repository<Project>
    {
        public Project_Repository(DBSibersContext context) : base(context) { }

        public override List<Project> GetAll()
        {
            return _dbSet.Include(project => project.CustomerCompany).Include(project => project.ExecutingCompany).Include(project => project.ProjectLeader).ToList();
        }

        public string GetProjectName(long id)
        {
            return _dbSet.Where(x => x.Id == id).SingleOrDefault()?.ProjectName;
        }

        public override string Save(Project model)
        {
            var leader = _context.Employees.SingleOrDefault(x => x.Id == model.ProjectLeaderId);
            try
            {
                if (model.ExecutingCompanyId != leader.Company)
                {
                    throw new Exception("Сотрудник работает на другую компанию");
                }
                _dbSet.Add(model);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return "Success";
        }
    }
}
