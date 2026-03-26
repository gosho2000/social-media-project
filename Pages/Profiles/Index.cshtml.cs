


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

namespace CourseSocialMedia.Pages.Profiles;


public class IndexModel: PageModel
{
	private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

	private readonly UserManager<ApplicationUser> _userManager;

	public ApplicationUser Profile { get; set; }

	public ICollection<Post> Posts { get; set; }

	public ApplicationUser? CurrentUser { get; set; }

	public IndexModel(UserManager<ApplicationUser> userManager, CourseSocialMedia.Data.ApplicationDbContext context)
	{
		_context = context;

		_userManager = userManager;

		Posts = new List<Post>();
	}

	public async Task<IActionResult> OnGet(string id)
	{
		CurrentUser = await _userManager.GetUserAsync(User);

		Profile = _context.Users.FirstOrDefault(p => p.Email == id);

		Posts = await  _context.Posts.Where(p => p.Uploader == Profile).Include(p => p.UserLikes).ToListAsync();

		if (Profile == null)
		{
			return StatusCode(404);
		}

		return Page();
	}
}
