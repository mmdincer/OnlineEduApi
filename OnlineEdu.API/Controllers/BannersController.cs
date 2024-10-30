using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _bannerService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id) 
        { 
            var value = _bannerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateBannerDto createBannerDto)
        {
            var newValues = _mapper.Map<Banner>(createBannerDto);
            _bannerService.TCreate(newValues);
            return Ok("Banner oluşturuldu.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        { 
            _bannerService.TDelete(id);
            return Ok("Banner silindi.");
        }

        [HttpPut]
        public IActionResult Update(UpdateBannerDto updateBannerDto)
        {
            var values = _mapper.Map<Banner>(updateBannerDto);
            _bannerService.TUpdate(values);
            return Ok("Banner güncellendi");
        }



    }
}
