using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff.Models;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Controllers
{
    public class ExecutingCompanyController : Controller
    {
        private ExecutingCompanyRepository _executingCompanyRepository;
        private IMapper _mapper;

        public ExecutingCompanyController(ExecutingCompanyRepository executingCompanyRepository, IMapper mapper)
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
            var company = _mapper.Map<ExecutingCompany>(viewModel);
            _executingCompanyRepository.Save(company);
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
            _executingCompanyRepository.Delete(company);
            return RedirectToAction("Table");
        }

    }
}
