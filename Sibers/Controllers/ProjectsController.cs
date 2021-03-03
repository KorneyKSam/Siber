using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sibers.DbStuff.Models;
using Sibers.DbStuff.Repository;
using Sibers.Models.Employee;
using Sibers.Models.ExecutingCompany;
using Sibers.Models.Project;
using System;
using System.Collections.Generic;

namespace Sibers.Controllers
{
    public class ProjectsController : Controller
    {
        private Project_Repository _projectRepository;
        private Customer_Company_Repository _customerCompanyRepository;
        private Executing_Company_Repository _executingCompanyRepository;
        private Employee_Repository _employeeRepository;
        private DbStuff.Repository.Employee_Project_Repository _employeeProjectRepository;
        private IMapper _mapper;

        public ProjectsController(Project_Repository repository,
            Customer_Company_Repository customerCompanyRepository,
            Executing_Company_Repository executingCompanyRepository,
            Employee_Repository employeeRepository,
            Employee_Project_Repository employeeProjectRepository,
            IMapper mapper)
        {
            _projectRepository = repository;
            _customerCompanyRepository = customerCompanyRepository;
            _executingCompanyRepository = executingCompanyRepository;
            _employeeRepository = employeeRepository;
            _employeeProjectRepository = employeeProjectRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Table()
        {
            var projects = _projectRepository.GetAll();
            var viewModel = new List<ProjectViewModel>();
            foreach (var project in projects)
            {
                viewModel.Add(_mapper.Map<ProjectViewModel>(project));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ChangeRow(long id)
        {
            var dbModel = _projectRepository.Get(id);
            var viewModel = _mapper.Map<ProjectViewModel>(dbModel);
            FillViewBags(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChangeRow(ProjectViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                FillViewBags(viewModel);
                return View(viewModel);
            }
            viewModel.DateTimeOfCreation = DateTime.Now;
            var dbModel = _mapper.Map<Project>(viewModel);
            var message = _projectRepository.Save(dbModel);
            if (message != "Success")
                TempData["Message"] = message;
            return RedirectToAction("Table");
        }

        public void FillViewBags(ProjectViewModel viewModel)
        {
            var customerCompanies = _customerCompanyRepository.GetAll();
            ViewBag.CustomerCompanies = customerCompanies;

            var executingCompanies = _executingCompanyRepository.GetAll();
            ViewBag.ExecutingCompanies = executingCompanies;

            var employeesDBModels = _employeeRepository.GetAll();

            var employeeViewModels = new List<EmployeeFullNameViewModel>();
            foreach (var employeeDbModel in employeesDBModels)
            {
                var model = new EmployeeFullNameViewModel();
                model.Id = employeeDbModel.Id;
                model.FullName = $"{employeeDbModel.LastName} {employeeDbModel.FirstName} {employeeDbModel.MiddleName}";
                employeeViewModels.Add(model);
            }
            ViewBag.Leader = employeeViewModels;
        }

        [HttpGet]
        public IActionResult DeleteRow(long id)
        {
            var dbModel = _projectRepository.Get(id);
            var viewModel = _mapper.Map<ProjectViewModel>(dbModel);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteRow(ProjectViewModel viewModel)
        {
            var dbModel = _mapper.Map<Project>(viewModel);
            var message = _projectRepository.Delete(dbModel);
            if (message != "Success")
                TempData["Message"] = message;
            return RedirectToAction("Table");
        }

        [HttpGet]
        public IActionResult ProjectEmployees(long projectId)
        {
            var employeesInsideProjectsDbModel = _employeeProjectRepository.GetAllEmployeesFromTheProject(projectId);
            var employeesInsideProjectViewModel = new List<EmployeeFullNameViewModel>();
            foreach (var dbModel in employeesInsideProjectsDbModel)
            {
                var viewModel = new EmployeeFullNameViewModel();
                viewModel.Id = dbModel.EmployeeId;
                viewModel.FullName = $"{dbModel.Employee.LastName} {dbModel.Employee.FirstName} {dbModel.Employee.MiddleName}";
                employeesInsideProjectViewModel.Add(viewModel);
            }

            var employeesOutsideProjectsDbModel = _employeeProjectRepository.GetAllEmployeesOutsideTheProject(projectId);
            var employeesOutsideProjectViewModel = new List<EmployeeFullNameViewModel>();
            foreach (var dbModel in employeesOutsideProjectsDbModel)
            {
                var viewModel = new EmployeeFullNameViewModel();
                viewModel.Id = dbModel.Id;
                viewModel.FullName = $"{dbModel.LastName} {dbModel.FirstName} {dbModel.MiddleName}";
                employeesOutsideProjectViewModel.Add(viewModel);
            }

            var employeeProjectViewModel = new EmployeeProjectViewModel()
            {
                ProjectId = projectId,
                ProjectName = _projectRepository.GetProjectName(projectId),
                EmployeesInsideTheProjectViews = employeesInsideProjectViewModel,
                EmployeesOutsideTheProjectViewModels = employeesOutsideProjectViewModel
            };

            return View(employeeProjectViewModel);
        }

        public ActionResult DeleteFromProject(long projectId, long employeeId)
        {
            var message = _employeeProjectRepository.Delete(employeeId, projectId);
            if (message != "Success")
                TempData["Message"] = message;
            return RedirectToAction("ProjectEmployees", new { @projectId = projectId });
        }

        public ActionResult AssignToProject(long projectId, long employeeid)
        {
            var dbmodel = new EmployeeProject()
            {
                DateTimeOfCreation = DateTime.Now,
                ProjectId = projectId,
                EmployeeId = employeeid
            };
            var message = _employeeProjectRepository.Add(dbmodel);
            if (message != "Success")
                TempData["Message"] = message;
            return RedirectToAction("ProjectEmployees", new { @projectId = projectId });
        }

    }
}
