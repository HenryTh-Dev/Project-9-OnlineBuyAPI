﻿using Microsoft.AspNetCore.Mvc;
using OnlineBuy.Application.DTOs;
using OnlineBuy.Application.Services.Interfaces;

namespace OnlineBuy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
            
        }
    }
}
