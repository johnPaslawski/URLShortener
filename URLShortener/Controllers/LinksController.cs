using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Domain.Models;
using URLShortener.DTO;
using URLShortener.EFCore.Infrasctructure.UOWs;
using URLShortener.Services;

namespace URLShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinksController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILinksService _linkServ;

        public LinksController(IUnitOfWork uow, ILinksService linkServ)
        {
            _uow = uow;
            _linkServ = linkServ;
        }

        // GET ___ api/links/{id}
        [HttpGet("{id}", Name = "GetLink")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Link>> GetLink(int id)
        {
            try
            {
                var link = await _uow.Links.Get(l => l.Id == id);
                if (link == null)
                {
                    return NotFound($"Link with id = {id} was not found.");
                }

                return Ok(link);
            }
            catch (Exception err)
            {
                return Problem($"Something went wrong in {nameof(GetLink)}. \n Problem details below: \n {err}");
            }
        }

        // GET ___ api/links
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Link>>> GetLinks()
        {
            try
            {
                var linksLinst = await _uow.Links.GetAll();
                return Ok(linksLinst);
            }
            catch (Exception err)
            {
                return Problem($"Something went wrong in {nameof(GetLinks)}. \n Problem details below: \n {err}");
            }
        }

        // POST ___ api/links
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLink([FromBody] LinkDto linkDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Invalid POST attempt in {nameof(CreateLink)}. MODEL STATE IS INVALID.");
            }

            try
            {
                var randomGuid = _linkServ.GenerateRandomLink();
                var randomLink = $"http://localhost:3000/s/{randomGuid}";

                var link = new Link
                {
                    GenuineURL = linkDto.GenuineURL,
                    ShortenedURL = randomLink
                };

                await _uow.Links.Add(link);
                await _uow.Save();

                //return CreatedAtRoute(new { id = link.Id }, link);
                return CreatedAtRoute("GetLink", new { id = link.Id }, link);
            }
            catch (Exception err)
            {
                return Problem($"Invalid POST attempt in {nameof(CreateLink)}. ERROR DURING ADDING LINK OCCURED. details: {err}");
            }
        }

    }
}
