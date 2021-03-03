using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff.Models;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using Sibers.Models.ExecutingCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Controllers
{
    public class ExecutingCompanyController : Controller
    {
        private Executing_Company_Repository _executingCompanyRepository;
        private IMapper _mapper;

        public ExecutingCompanyController(Executing_Company_Repository executingCompanyRepository, IMapper mapper)
        {
            _executingCompanyRepository = executingCompanyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Table()
        {
            var companies = _executingCompanyRepository.GetAll();
            var viewModel = new List<ExecutingCompanyViewModel>();
            foreach (var company in companies)
            {
                viewModel.Add(_mapper.Map<ExecutingCompanyViewModel>(company));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ChangeRow(long id)
        {
            var company = _executingCompanyRepository.Get(id);
            var viewModel = _mapper.Map<ExecutingCompanyViewModel>(company);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChangeRow(ExecutingCompanyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var company = _mapper.Map<ExecutingCompany>(viewModel);
            var message = _executingCompanyRepository.Save(company);
            if (message != "Success")
                TempData["Message"] = message;
            return RedirectToAction("Table");
        }

        [HttpGet]
        public IActionResult DeleteRow(long id)
        {
            var company = _executingCompanyRepository.Get(id);
            var viewModel = _mapper.Map<ExecutingCompanyViewModel>(company);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteRow(ExecutingCompanyViewModel viewModel)
        {
            var company = _mapper.Map<ExecutingCompany>(viewModel);
            var message = _executingCompanyRepository.Delete(company);
            if (message != "Success")
                TempData["Message"] = message;
            return RedirectToAction("Table");
        }

    }
}
