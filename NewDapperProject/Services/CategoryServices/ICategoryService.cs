using NewDapperProject.Dtos.CategoryDtos;

namespace DapperProject.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(int id);
    Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);
}