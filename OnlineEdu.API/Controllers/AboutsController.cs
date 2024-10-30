﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Hakkımızda Alanı silindi.");
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDto createAboutDto)
        { 
            var newValue = _mapper.Map<About>(createAboutDto);
            _aboutService.TCreate(newValue);
            return Ok("Yeni hakkımızda alanı oluşturuldu.");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            var newValue = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(newValue);
            return Ok("Hakkımızda alanı güncelleştirildi");
        }



    }
}
