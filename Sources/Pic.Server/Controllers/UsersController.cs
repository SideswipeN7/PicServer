using System;
using System.Collections.Generic;
using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pic.Repository.Models;
using Pic.Server.DTO;
using Pic.Shared.Interfaces;

namespace Pic.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICrudService<UserEntity> service;
        private readonly IMapper mapper;

        public UsersController(ICrudService<UserEntity> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            try
            {
                var users = service.Get();
                if (users is null)
                {
                    users = new List<UserEntity>();
                }

                return Ok(mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserDto>>(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{username}")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<UserDto> Get(string username)
        {
            try
            {
                var user = service.Get(x => x.Username == username);
                if (user is null)
                {
                    return NotFound(username);
                }

                return Ok(mapper.Map<UserEntity, UserDto>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Update(UserDto userDto)
        {
            try
            {
                var user = mapper.Map<UserDto, UserEntity>(userDto);

                service.Update(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Add(UserDto userDto)
        {
            try
            {
                var user = mapper.Map<UserDto, UserEntity>(userDto);

                service.Add(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{login}")]
        public IActionResult Delete(string login)
        {
            try
            {
                service.Delete(x => x.Username != login);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}