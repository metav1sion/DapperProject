using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.CategoryDtos;

namespace DapperProject.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly DapperContext _dapperContext;

    public CategoryService(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<List<ResultCategoryDto>> GetCategoryAsync()
    {
        string query = "Select * From TblCategory";
        var connection = _dapperContext.CreateConnection();
        var values = await connection.QueryAsync<ResultCategoryDto>(query);
        return values.ToList();
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        string query = "insert into TblCategory(CategoryName) values (@categoryName)";
        var paramaters = new DynamicParameters();
        paramaters.Add("@categoryName",createCategoryDto.CategoryName);
        var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(query, paramaters);
    }

    public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        string query = "Delete From TblCategory Where Category=@categoryId";
        var paramaters = new DynamicParameters();
        paramaters.Add("@categoryId",id);
        var connection = _dapperContext.CreateConnection();
        await connection.ExecuteAsync(query, paramaters);
    }

    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
    {
        string query = "Select * From TblCategory Where CategoryId=@categoryId";
        var paramaters = new DynamicParameters();
        paramaters.Add("@categoryId",id);
        var connection = _dapperContext.CreateConnection();
        var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, paramaters);
        return values;
    }
}