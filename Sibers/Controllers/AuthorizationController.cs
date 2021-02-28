using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.DbStuff;
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
    public class AuthorizationController : Controller
    {
        private UserRepository _userRepository;
        private IMapper _mapper;

        public AuthorizationController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel userViewModel)
        {
            //var user = new User()
            //{
            //    Email = userViewModel.Email,
            //    Login = userViewModel.Login,
            //    Password = userViewModel.Password,
            //    DisplayName = userViewModel.DisplayName
            //};

            var user = _mapper.Map<User>(userViewModel);
            _userRepository.Save(user);
            return View();
        }

    }
}
