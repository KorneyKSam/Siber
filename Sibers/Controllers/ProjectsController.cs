using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff.Models;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.Controllers
{
    public class ProjectsController : Controller
    {
        private ProjectRepository _projectRepository;
        private CustomerCompanyRepository _customerCompanyRepository;
        private ExecutingCompanyRepository _executingCompanyRepository;
        private EmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public ProjectsController(ProjectRepository repository,
            CustomerCompanyRepository customerCompanyRepository,
            ExecutingCompanyRepository executingCompanyRepository,
            EmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _projectRepository = repository;
            _customerCompanyRepository = customerCompanyRepository;
            _executingCompanyRepository = executingCompanyRepository;
            _employeeRepository = employeeRepository;
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

            var customerCompanies = _customerCompanyRepository.GetAll();
            customerCompanies.Insert(0, new CustomerCompany() { CompanyName = "Выберите компанию исполнителя", Id = 0 });
            ViewBag.CustomerCompanies = customerCompanies;

            var executingCompanies = _executingCompanyRepository.GetAll();
            executingCompanies.Insert(0, new ExecutingCompany() { CompanyName = "Выберите компанию заказчика", Id = 0 });
            ViewBag.ExecutingCompanies = executingCompanies;

            var employeesDBModels = _employeeRepository.GetAll();
            employeesDBModels.Insert(0, new Employee() { LastName = "Выберите руководителя проекта", Id = 0 });
            var employeeViewModels = new List<EmployeeFullNameViewModel>();
            foreach (var employeeDbModel in employeesDBModels)
            {
                var model = new EmployeeFullNameViewModel();
                model.Id = employeeDbModel.Id;
                model.FullName = $"{employeeDbModel.LastName} {employeeDbModel.FirstName} {employeeDbModel.MiddleName}";
                employeeViewModels.Add(model);
            }
            ViewBag.Leader = employeeViewModels;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChangeRow(ProjectViewModel viewModel)
        {
            viewModel.DateTimeOfCreation = DateTime.Now;
            var dbModel = _mapper.Map<Project>(viewModel);
            _projectRepository.Save(dbModel);
            return RedirectToAction("Table");
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
            _projectRepository.Delete(dbModel);
            return RedirectToAction("Table");
        }

        [HttpGet]
        public IActionResult ProjectInfo(long id)
        {
            var dbModel = _projectRepository.Get(id);
            //EmployeeFullNameViewModel
            var viewModel = _mapper.Map<ProjectInfoViewModel>(dbModel);
            return View(viewModel);
        }
    }
}
