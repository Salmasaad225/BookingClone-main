﻿using BookingClone.Application.Features.continent.commands.AddContinent;
using BookingClone.Application.Features.continent.commands.DeleteContinent;
using BookingClone.Application.Features.continent.commands.UpdateContinent;
using BookingClone.Application.Features.continent.queries.GetAllcontinent;
using BookingClone.Application.Features.continent.queries.GetContinentById;
using BookingClone.Application.Features.country.commands.AddCountry;
using BookingClone.Application.Features.country.commands.DeleteCountry;
using BookingClone.Application.Features.country.commands.UpdateCountry;
using BookingClone.Application.Features.country.queries.GitAllCountries;
using BookingClone.Application.Features.country.queries.GitCountryById;
using BookingClone.Infrastructure.Data;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingClone.API.Controllers.V1;
[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{

    private readonly BookingDbContext _context;
    private readonly IMediator _mediator;

    public CountriesController(BookingDbContext bookingDbContext, IMediator mediator)
    {
        _context = bookingDbContext;
        _mediator = mediator;
    }



    [HttpGet]
    public IActionResult GetAllCountry()
    {
        return Ok(_mediator.Send(new GitAllCountriesQuery()));
    }


    [HttpGet("{id}")]

    public async Task<IActionResult> GetCountryById([FromRoute] int id)
    {
        return Ok(await _mediator.Send(new GitCountryByIdQuery(id)));
    }





    [HttpPost]
    public async Task<IActionResult> AddCountry([FromBody] AddCountryCommmand addCountryCommmand)
    {

        return Ok(await _mediator.Send(addCountryCommmand));

    }



    [HttpDelete]
    public async Task<IActionResult> DeleteCountry([FromBody] DeleteCountryCommmand deleteCountryCommmand)
    {
        return Ok(await _mediator.Send(deleteCountryCommmand));

    }

    [HttpPut]
    public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryCommmand updateCountryCommmand)
    {
        return Ok(await _mediator.Send(updateCountryCommmand));
    }
}