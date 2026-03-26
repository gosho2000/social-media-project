


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

namespace CourseSocialMedia.Pages;

public class PostModel: PageModel
{
	private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

	private readonly UserManager<ApplicationUser> _userManager;

	public Post Post { get; set; }

	public ApplicationUser CurrentUser { get; set; }

	public PostModel(UserManager<ApplicationUser> userManager, CourseSocialMedia.Data.ApplicationDbContext context)
	{
		_context = context;

		_userManager = userManager;
	}

	public async Task<IActionResult> OnGetAsync(int id)
	{
		Post = _context.Posts.Include(p => p.Uploader).Include(p => p.UserLikes).Include(p => p.Comments).FirstOrDefault(p => p.Id == id);

		CurrentUser = await _userManager.GetUserAsync(User);

		if (Post == null)
		{
			return StatusCode(404);
		}

		return Page();
	}
}
