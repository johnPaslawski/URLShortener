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
        private readonly string _baseURL;

        public LinksController(IUnitOfWork uow, ILinksService linkServ)
        {
            _uow = uow;
            _linkServ = linkServ;
            _baseURL = "http://localhost:3000/s/";
        }

        /// <summary>
        /// THIS METHOD RETURNS SPECIFIC LINK FOUND BASED ON GIVEN GIUD
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// 
        // GET : api/links/{guid}
        [HttpGet("{guid}", Name = "GetLink")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Link>> GetLink(string guid)
        {
            try
            {
                var link = await _uow.Links.Get(l => l.ShortenedURL == $"{_baseURL}{guid}");
                if (link == null)
                {
                    return NotFound($"Link with guid = {guid} was not found.");
                }

                return Ok(link);
            }
            catch (Exception err)
            {
                return Problem($"Something went wrong in {nameof(GetLink)}. \n Problem details below: \n {err}");
            }
        }

        /// <summary>
        /// THIS METHOD RETURNS ALL LINKS IN DATABASE. THIS IS ONLY FOR PRESENTATION PURPOSES NOT TO BE USED WITH LARGE DATABASE
        /// </summary>
        /// <returns></returns>
        /// 
        // GET : api/links
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

        /// <summary>
        /// THIS METHOD POST NEW LINK BASED ON RECIEVED LINK-GENUINE URL FROM CLIENT SIDE
        /// </summary>
        /// <param name="linkDto"></param>
        /// <returns></returns>
        /// 
        // POST : api/links
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
                var randomLink = $"{_baseURL}{randomGuid}";
                var link = new Link
                {
                    GenuineURL = linkDto.GenuineURL,
                    ShortenedURL = randomLink,
                    Guid = randomGuid
                };
                await _uow.Links.Add(link);
                await _uow.Save();

                return CreatedAtRoute("GetLink", new { guid = link.Guid }, link);
            }
            catch (Exception err)
            {
                return Problem($"Invalid POST attempt in {nameof(CreateLink)}. ERROR DURING ADDING LINK OCCURED. details: {err}");
            }
        }

    }
}
