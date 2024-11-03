﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subscriberService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _subscriberService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var value = _subscriberService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _subscriberService.TDelete(id);
            return Ok("Subscriber Alanı silindi.");
        }

        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(createSubscriberDto);
            _subscriberService.TCreate(newValue);
            return Ok("Yeni Subscriber alanı oluşturuldu.");
        }

        [HttpPut]
        public IActionResult Update(UpdateSubscriberDto updateSubscriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(updateSubscriberDto);
            _subscriberService.TUpdate(newValue);
            return Ok("Subscriber alanı güncelleştirildi");
        }
    }
}
