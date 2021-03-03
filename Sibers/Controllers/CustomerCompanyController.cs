using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff.Models;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using Sibers.Models.CustomerCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Controllers
{
    public class CustomerCompanyController : Controller
    {
        private Customer_Company_Repository _customerCompanyRepository;
        private IMapper _mapper;

        public CustomerCompanyController(Customer_Company_Repository customerCompanyRepository, IMapper mapper)
        {
            _customerCompanyRepository = customerCompanyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Table()
        {
            var companies = _customerCompanyRepository.GetAll();
            var viewModel = new List<CustomerCompanyViewModel>();
            foreach (var company in companies)
            {
                viewModel.Add(_mapper.Map<CustomerCompanyViewModel>(company));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ChangeRow(long id)
        {
            var company = _customerCompanyRepository.Get(id);
            var viewModel = _mapper.Map<CustomerCompanyViewModel>(company);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChangeRow(CustomerCompanyViewModel viewModel)
        {
            var company = _mapper.Map<CustomerCompany>(viewModel);
            _customerCompanyRepository.Save(company);
            return RedirectToAction("Table");
        }

        [HttpGet]
        public IActionResult DeleteRow(long id)
        {
            var company = _customerCompanyRepository.Get(id);
            var viewModel = _mapper.Map<CustomerCompanyViewModel>(company);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteRow(CustomerCompanyViewModel viewModel)
        {
            var company = _mapper.Map<CustomerCompany>(viewModel);
            _customerCompanyRepository.Delete(company);
            return RedirectToAction("Table");
        }

    }
}
