﻿using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace CityInfo.API.Controller
   
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository,IMapper  mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities(
            [FromQuery(Name ="filteronname")]string? name)
        {
            var cityEntities = await _cityInfoRepository.GetCitiesAsync();
            
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
        }


        [HttpGet("{id}")]
       
          public async Task< IActionResult> GetCity(int id, bool includePointsOfInterest =false)
        {
            var city =await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if (city == null )
            {
                return NotFound();
            }
            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }
            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
        

    }

}
