using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using API.Data;
using API.Model;
using API.Model.Request;
using API.Model.Response;
using AutoMapper;

namespace API.Controllers;

public class CategoryController : BaseAPIController
{
	private readonly MyDatabase _db;
	private readonly IMapper _map;

	public CategoryController(MyDatabase myDatabase, IMapper map) 
	{
		_db = myDatabase;
		_map = map;
	}
	[HttpGet] //localhost:port/api/category/
	public async Task<IActionResult> GetCategory() 
	{
		List<Category> categories = await _db.Categories.ToListAsync();
		if(categories.Count() == 0) 
		{
			return NotFound();
		}
		List<CategoryResponse> response = _map.Map<List<CategoryResponse>>(categories);
		return Ok(response);
	}
	[HttpGet] //localhost:port/api/category/id
	[Route("{id}")]
	public async Task<IActionResult> GetCategory([FromRoute] int id) 
	{
		var category = await _db.Categories.FindAsync(id); 
		if(category is null) 
		{
			return NotFound();
		}
		return Ok(category);
	}
	[HttpPost] //localhost:port/api/category/
	public async Task<IActionResult> CreateCategory([FromBody]CategoryRequest request) 
	{
		var category = new Category()
		{
			CategoryName = request.CategoryName,
			Description = request.Description
		};
		_db.Categories.Add(category);
		await _db.SaveChangesAsync();
		return Ok(category);
	} 
	[HttpPut] //localhost:port/api/category/{id} body: CategoryRequest
	[Route("{id}")]
	public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody]CategoryRequest request) 
	{
		Category? category = _map.Map<Category>(request);
		_db.Categories.Add(category);
		await _db.SaveChangesAsync();
		return Ok(category);
	}
	[HttpDelete] //localhost:port/api/category/{id}
	[Route("{id}")]
		public async Task<IActionResult> DeleteCategory([FromRoute] int id) 
	{
		Category? category = await _db.Categories.FindAsync(id);
		if(category is null) 
		{
			return NotFound();
		}
		_db.Categories.Remove(category);
		await _db.SaveChangesAsync();
		return Ok(category);
	}
}
