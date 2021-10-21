using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Business.Abstract;
using NoteApp.Entities;
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

        public IActionResult Post([FromBody] CategoryModel model)
        {
            Category category = new Category
            {
                CategoryName = model.CategoryName
            };
            return Ok();
        }
    }
}
