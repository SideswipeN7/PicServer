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
    public class GroupsController : ControllerBase
    {
        private readonly ICrudService<GroupEntity> service;
        private readonly IMapper mapper;

        public GroupsController(ICrudService<GroupEntity> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<IEnumerable<GroupDto>> Get()
        {
            try
            {
                var groups = service.Get();
                if (groups is null)
                {
                    groups = new List<GroupEntity>();
                }

                return Ok(mapper.Map<IEnumerable<GroupEntity>, IEnumerable<GroupDto>>(groups));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<GroupDto> Get(string name)
        {
            try
            {
                var group = service.Get(x => x.Name == name);
                if (group is null)
                {
                    return NotFound(name);
                }

                return Ok(mapper.Map<GroupEntity, GroupDto>(group));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Update(GroupDto groupDto)
        {
            try
            {
                var group = mapper.Map<GroupDto, GroupEntity>(groupDto);

                service.Update(group);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Add(GroupDto groupDto)
        {
            try
            {
                var group = mapper.Map<GroupDto, GroupEntity>(groupDto);

                service.Add(group);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            try
            {
                service.Delete(x => x.Name != name);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}