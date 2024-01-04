using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Data;
using WebMVC.Models;

namespace WebMVC.Controllers;

public class CategoryController : Controller
{
	private readonly MyDatabase _db;
	public CategoryController(MyDatabase myDatabase) 
	{
		_db = myDatabase;
	}
	public async Task<IActionResult> Index() 
	{
		List<Category> categories = await _db.Categories.ToListAsync();
		return View(categories);
	}
	public IActionResult Create() 
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Create(Category category) 
	{
		if(!ModelState.IsValid) 
		{
			return View();
		}
		_db.Categories.Add(category);
		await _db.SaveChangesAsync();
		TempData["Success"] = $"Create {category.CategoryName} is success";
		return RedirectToAction("Index","Category");
	}
	public async Task<IActionResult> Update(Guid id) 
	{
		var category = await _db.Categories.FindAsync(id);
		return View(category);
	}
	[HttpPost]
	public async Task<IActionResult> Update(Category category) 
	{
		_db.Categories.Update(category);
		await _db.SaveChangesAsync();
		return RedirectToAction("Index","Category");
	}
	public async Task<IActionResult> Delete(Guid id) 
	{
		var category = await _db.Categories.FindAsync(id);
		return View(category);
	}
	[HttpPost]
	public async Task<IActionResult> Delete(Category category) 
	{
		_db.Categories.Remove(category);
		await _db.SaveChangesAsync();
		return RedirectToAction("Index","Category");
	}
}
