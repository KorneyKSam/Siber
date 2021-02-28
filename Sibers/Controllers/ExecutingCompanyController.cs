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
    public class ExecutingCompanyController : Controller
    {
        private ExecutingCompanyRepository _executingCompanyRepository;
        private IMapper _mapper;

        public ExecutingCompanyController(ExecutingCompanyRepository executingCompanyRepository, IMapper mapper)
        {
            _executingCompanyRepository = executingCompanyRepository;
            _mapper = mapper;
        }

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
    }
}
