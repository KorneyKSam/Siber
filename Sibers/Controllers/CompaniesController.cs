using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Controllers
{
    public class CompaniesController : Controller
    {
        private CustomerCompanyRepository _customerCompanyRepository;
        private IMapper _mapper;

        public CompaniesController(CustomerCompanyRepository customerCompanyRepository, IMapper mapper)
        {
            _customerCompanyRepository = customerCompanyRepository;
            _mapper = mapper;
        }

        public IActionResult CustomerCompany()
        {
            var companies = _customerCompanyRepository.GetAll();
            var viewModel = new List<CompanyViewModel>();
            foreach (var company in companies)
            {
                viewModel.Add(_mapper.Map<CompanyViewModel>(company));
            }
            return View(viewModel);
        }

        public IActionResult ExecutingCompany()
        {
            return View();
        }
    }
}
