using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff.Models;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using System;
using System.Collections.Generic;

namespace Sibers.Controllers
{
    public class EmployeesController : Controller
    {
        private CustomerCompanyRepository _customerCompanyRepository;
        private EmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeesController(EmployeeRepository employeeRepository, CustomerCompanyRepository customerCompanyRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ;
            _customerCompanyRepository = customerCompanyRepository;
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

            var companies = _customerCompanyRepository.GetAll();
            companies.Insert(0, new CustomerCompany() { CompanyName = "Выберите компанию", Id = 0 });
            ViewBag.companies = companies;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChangeRow(EmployeeViewModel viewModel)
        {
            viewModel.DateTimeOfCreation = DateTime.Now;
            var dbModel = _mapper.Map<Employee>(viewModel);
            _employeeRepository.Save(dbModel);
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
            _employeeRepository.Delete(dbModel);
            return RedirectToAction("Table");
        }

    }
}
