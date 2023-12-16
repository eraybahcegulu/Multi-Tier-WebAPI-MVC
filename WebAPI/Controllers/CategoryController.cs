﻿using BLL.ManagerServices.Abstracts;
using ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebAPI.Models.Categories.RequestModels;
using WebAPI.Models.Categories.ResponseModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel item)
        {
            Category c = new()
            {
                CategoryName = item.CategoryName,
                Description = item.Description
            };

            string result = _categoryManager.Add(c);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryResponseModel> categories = _categoryManager.Select(x => new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                CategoryID = x.ID
            }).ToList();

            return Ok(categories);
        }
    }
}