using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FotoQuestGo.DataSubmissionService.Interfaces;
using FotoQuestGoRepository.Models;
using FotoQuestGoRepository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FotoQuestGoCommandApi.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUserUnitOfWork userUnitOfWork, IMapper mapper)
        {
            _userUnitOfWork = userUnitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <returns>OK</returns>
        /// <returns>BadRequest</returns>
        [HttpPost()]
        [ProducesResponseType(typeof(UserViewModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(UserViewModel userViewModel)
        {
            var userData = _mapper.Map<UserDetails>(userViewModel);
            var user = await _userUnitOfWork.UserRepository.AddAsync(userData);
            await _userUnitOfWork.CompleteAsync();
            var userVd = _mapper.Map<UserViewModel>(user);
            return Ok(user);
        }


        /// <summary>
        /// Get User
        /// </summary>
        /// <returns>OK</returns>
        /// <returns>BadRequest</returns>
        /// <returns>NotFound</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(Guid? Id)
        {
            if (Id.HasValue == false)
            {
                return BadRequest();
            }
            var user = _userUnitOfWork.UserRepository.Get(Id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}