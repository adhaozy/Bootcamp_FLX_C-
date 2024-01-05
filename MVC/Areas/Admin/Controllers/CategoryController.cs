using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Data;
using WebMVC.Models;
using WebMVC.Persistence.Repository;

namespace WebMVC.Controllers;

public class CategoryController : Controller
{
	
	private readonly ICategoryRepository _category;	
	public CategoryController(ICategoryRepository category) 
	{
		_category = category;
	}
	public async Task<IActionResult> Index() 
	{
		IEnumerable<Category> categories = await _category.GetAll();
		return View(categories.ToList());
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
		_category.Add(category);
		await _category.SaveAsync();
		TempData["Success"] = $"Create {category.CategoryName} is success";
		return RedirectToAction("Index","Category");
	}
	public async Task<IActionResult> Update(Guid id) 
	{
		var category = await _category.Get(id);
		return View(category);
	}
	[HttpPost]
	public async Task<IActionResult> Update(Category category) 
	{
		_category.Update(category);
		await _category.SaveAsync();
		return RedirectToAction("Index","Category");
	}
	public async Task<IActionResult> Delete(Guid id) 
	{
		var category = await _category.Get(id);
		return View(category);
	}
	[HttpPost]
	public async Task<IActionResult> Delete(Category category) 
	{
		_category.Remove(category);
		await _category.SaveAsync();
		return RedirectToAction("Index","Category");
	}
}
