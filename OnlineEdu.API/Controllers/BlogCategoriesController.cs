using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogCategoryDtos;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IGenericService<BlogCategory> _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogCategoryService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var value = _blogCategoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var newValues = _mapper.Map<BlogCategory>(createBlogCategoryDto);
            _blogCategoryService.TCreate(newValues);
            return Ok("Blog kategorisi oluşturuldu.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _blogCategoryService.TDelete(id);
            return Ok("Blog kategorisi silindi.");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var values = _mapper.Map<BlogCategory>(updateBlogCategoryDto);
            _blogCategoryService.TUpdate(values);
            return Ok("Blog kategorisi güncellendi");
        }
    }
}
