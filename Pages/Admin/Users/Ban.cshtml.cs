


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseSocialMedia.Data;
using CourseSocialMedia.Models;

namespace CourseSocialMedia.Pages.Admin.Users;

public class BanModel: PageModel
{
	private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

	public ApplicationUser User { get; set; }

	public BanModel(CourseSocialMedia.Data.ApplicationDbContext context)
	{
		_context = context;
	}

	public IActionResult OnGet(string id)
	{
		User = _context.Users.FirstOrDefault(u => u.Id == id);

		if (User == null)
		{
			return RedirectToPage("Index");
		}

		return Page();
	}

	public async Task<IActionResult> OnPostAsync(string id)
	{
		User = _context.Users.FirstOrDefault(u => u.Id == id);

		if (User == null)
		{
			return RedirectToPage("Index");
		}

		if (!User.IsBanned)
		{

		User.IsBanned = true;

		User.LockoutEnabled = true;

		User.LockoutEnd = DateTimeOffset.MaxValue;

		_context.Update(User);

		await _context.SaveChangesAsync();

		}
		else
		{
			User.IsBanned = false;

			User.LockoutEnabled = false;

			User.LockoutEnd = null;

		_context.Update(User);

		await _context.SaveChangesAsync();
		}

		return RedirectToPage("Index");
	}
}
