using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Business.Abstract;
using NoteApp.Entities;
using NoteApp.WebApiService.Filters;
using NoteApp.WebApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [CategoryException]
        public IActionResult Get()
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                Entities = categoryService.GetAll(),
                IsSuccess = true,
                HasError = false
            };
            response.EntitesCount = response.Entities.Count();

            return Ok(response);
        }

        [HttpGet("{id}")]
        [CategoryException]
        public IActionResult Get(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                Entity = categoryService.GetById(id),
                IsSuccess = true,
                HasError = false
            };

            return Ok(response);
        }
        [HttpPost]
        [CategoryException]
        [CategoryValidate]
        public IActionResult Post([FromBody] CategoryModel model)
        {
            Category category = new Category
            {
                CategoryName = model.CategoryName
            };
            categoryService.Add(category);
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                Entity = category,
                IsSuccess = true,
                HasError = false
            };
            return Ok();
        }
        [HttpPut]
        [CategoryException]
        [CategoryValidate]
        public IActionResult Put(int id, [FromBody] CategoryModel model)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();            
            var category = categoryService.GetById(id);
            if (category == null)
            {
                response.HasError = true;
                response.IsSuccess = false;
                response.Errors.Add("Category Not Found");
                return BadRequest(response);
            }
            else
            {
                category.CategoryName = model.CategoryName;
                categoryService.Update(category);
                response.IsSuccess = true;
                response.HasError = false;
                return Ok(response);
            }
        }
        [HttpDelete]
        [CategoryException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();
            var category = categoryService.GetById(id);
            if (category == null)
            {
                response.HasError = true;
                response.IsSuccess = false;
                response.Errors.Add("Category Not Found");
                return BadRequest(response);
            }
            else
            {
                categoryService.Delete(category);
                response.IsSuccess = true;
                response.HasError = false;
                return Ok(response);
            }
        }
    }
}
