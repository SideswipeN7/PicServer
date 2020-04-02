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
    public class AlbumsController : ControllerBase
    {
        private readonly ICrudService<AlbumEntity> service;
        private readonly IMapper mapper;

        public AlbumsController(ICrudService<AlbumEntity> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<IEnumerable<AlbumDto>> Get()
        {
            try
            {
                var albums = service.Get();
                if (albums is null)
                {
                    albums = new List<AlbumEntity>();
                }

                return Ok(mapper.Map<IEnumerable<AlbumEntity>, IEnumerable<AlbumDto>>(albums));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{title}")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<AlbumDto> Get(string title)
        {
            try
            {
                var album = service.Get(x => x.Title == title);
                if (album is null)
                {
                    return NotFound(title);
                }

                return Ok(mapper.Map<AlbumEntity, AlbumDto>(album));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Add(AlbumDto albumDto)
        {
            try
            {
                var album = mapper.Map<AlbumDto, AlbumEntity>(albumDto);
                service.Add(album);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("check/{title}")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<bool> CheckExists(string title)
        {
            try
            {
                return Ok(service.CheckIfExists(x => x.Title == title));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Edit(AlbumDto albumDto)
        {
            try
            {
                var album = mapper.Map<AlbumDto, AlbumEntity>(albumDto);
                service.Update(album);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{title}")]
        public IActionResult Delete(string title)
        {
            try
            {
                service.Delete(x => x.Title == title);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}