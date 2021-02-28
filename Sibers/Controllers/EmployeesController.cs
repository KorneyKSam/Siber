using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using System.Collections.Generic;

namespace Sibers.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeesController(EmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ;
            _mapper = mapper;
        }

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

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Change()
        {
            return View();
        }
    }
}
