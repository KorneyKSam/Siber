using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private IMapper _mapper;

        public ProjectsController(ProjectRepository repository, IMapper mapper)
        {
            _projectRepository = repository;
            _mapper = mapper;
        }

        public IActionResult Table()
        {
            var projects = _projectRepository.GetAll();
            var viewModel = new List<ProjectViewModel>();
            foreach (var project in projects)
            {
                viewModel.Add(_mapper.Map<ProjectViewModel>(project));
            }
            return View();
        }
    }
}
