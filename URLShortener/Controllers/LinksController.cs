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

namespace URLShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinksController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public LinksController(IUnitOfWork uow)
        {
            _uow = uow;
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
    }
}
