﻿using DapperProject.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using NewDapperProject.Dtos.CategoryDtos;

namespace NewDapperProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetCategoryAsync();
            return View(values);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _categoryService.GetByIdCategoryAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("CategoryList");
        }
    }
}
