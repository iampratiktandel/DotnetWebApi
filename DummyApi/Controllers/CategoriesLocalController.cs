using DummyApi.Data;
using DummyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DummyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesLocalController : ControllerBase
{
    private readonly ApiDbContext _dbcontext;

    public CategoriesLocalController(ApiDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    private static List<Category> categories = new List<Category>()
    {
        new Category() { Id = 0, Name = "Apartment", ImageUrl = "apartment.png" },
        new Category() { Id = 1, Name = "Apartment", ImageUrl = "apartment.png" }
    };

    [HttpGet] // api/categories
    public IEnumerable<Category> Get()
    {
        return categories;
    }

    [HttpPost]
    public void Post([FromBody] Category category)
    {
        categories.Add(category);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Category category)
    {
        categories[id] = category;
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        categories.RemoveAt(id);
    }

}
