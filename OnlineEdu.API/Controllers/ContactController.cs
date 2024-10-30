using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _contactService.TDelete(id);
            return Ok("Hakkımızda Alanı silindi.");
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            var newValue = _mapper.Map<Contact>(createContactDto);
            _contactService.TCreate(newValue);
            return Ok("Contact alanı oluşturuldu.");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var newValue = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(newValue);
            return Ok("Contact güncelleştirildi");
        }
    }
}
