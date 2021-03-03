using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff.Models;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using Sibers.Models.Employee;
using System;
using System.Collections.Generic;

namespace Sibers.Controllers
{
    public class EmployeesController : Controller
    {
        private Executing_Company_Repository _executingCompanyRepository;
        private Employee_Repository _employeeRepository;
        private IMapper _mapper;

        public EmployeesController(Employee_Repository employeeRepository, Executing_Company_Repository executingCompanyRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _executingCompanyRepository = executingCompanyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Table()
        {
            var emloyees = _employeeRepository.GetAll();
            var viewModel = new List<EmployeeViewModel>();
            foreach (var employee in emloyees)
            {
                viewModel.Add(_mapper.Map<EmployeeViewModel>(employee));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ChangeRow(long id)
        {
            var dbModel = _employeeRepository.Get(id);
            var viewModel = _mapper.Map<EmployeeViewModel>(dbModel);
            FillViewBag();
            return View(viewModel);
        }

        private void FillViewBag()
        {
            var companies = _executingCompanyRepository.GetAll();
            companies.Insert(0, new ExecutingCompany() { CompanyName = "Выберите компанию", Id = 0 });
            ViewBag.companies = companies;
        }

        [HttpPost]
        public IActionResult ChangeRow(EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                FillViewBag();
                return View(viewModel);
            }
            viewModel.DateTimeOfCreation = DateTime.Now;
            var dbModel = _mapper.Map<Employee>(viewModel);
            var message = _employeeRepository.Save(dbModel);
            if (message != "Success")
                TempData["Message"] = message;
            return RedirectToAction("Table");
        }

        [HttpGet]
        public IActionResult DeleteRow(long id)
        {
            var dbModel = _employeeRepository.Get(id);
            var viewModel = _mapper.Map<EmployeeViewModel>(dbModel);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteRow(EmployeeViewModel viewModel)
        {
            var dbModel = _mapper.Map<Employee>(viewModel);
            var message = _employeeRepository.Delete(dbModel);
            if (message != "Success")
                TempData["Message"] = message;
            return RedirectToAction("Table");
        }

    }
}
