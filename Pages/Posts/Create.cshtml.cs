


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseSocialMedia.Data;
using CourseSocialMedia.Models;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

namespace CourseSocialMedia.Pages.NonAdmin.Posts;

public class CreateModel : PageModel
{
	private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

	private readonly UserManager<ApplicationUser> _userManager;

	public CreateModel(UserManager<ApplicationUser> userManager, CourseSocialMedia.Data.ApplicationDbContext context)
	{
		_context = context;

		_userManager = userManager;
	}

	public async Task<IActionResult> OnPostAsync()
	{
		string body = Request.Form["PostBody"];

		string title = Request.Form["PostTitle"];

		// int id = int.Parse(Request.Query["Id"]);

		ApplicationUser user = await _userManager.GetUserAsync(User);

		// Post post = _context.Posts.FirstOrDefault(p => p.Id == id);

		if (user == null)
		{
			return RedirectToPage("/Account/Login", new { area = "Identity" });
		}

		// if (post == null)
		// {
		// 	return StatusCode(404);
		// }

		if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(title))
		{
			return RedirectToPage("../Profiles/Index", new { id = user.Email });
		}


		// Comment comment = new Comment()
		// {
		// 	Body = body,
		// 	User = user,
		// 	Post = post
		// };

		Post post = new Post()
		{
			Title = title,
			Body = body,
			Uploader = user
		};

		_context.Posts.Add(post);

		await _context.SaveChangesAsync();

		return RedirectToPage("../Profiles/Index", new { id = user.Email });
	}
}
