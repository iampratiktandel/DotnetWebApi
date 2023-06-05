using DummyApi.Data;
using DummyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DummyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    ApiDbContext _dbContext = new ApiDbContext();

    [HttpGet]
    public IEnumerable<Category> Get()
    {
        return _dbContext.Categories;
    }

    [HttpGet("{id}")]
    public Category Get(int id)
    {
        return _dbContext.Categories.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost]
    public void Post([FromBody] Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Category categoryObj)
    {
        var category = _dbContext.Categories.Find(id);
        category.Name = categoryObj.Name;
        category.ImageUrl = categoryObj.ImageUrl;
        _dbContext.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var category = _dbContext.Categories.Find(id);
        _dbContext.Categories.Remove(category);
        _dbContext.SaveChanges();
    }

}