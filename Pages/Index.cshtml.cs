using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

using CourseSocialMedia.Models;

namespace CourseSocialMedia.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

		private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

		private readonly UserManager<ApplicationUser> _userManager;

		public ApplicationUser? CurrentUser { get; set; }

		public ICollection<Post> Posts { get; set; }

    public IndexModel(ILogger<IndexModel> logger,
				UserManager<ApplicationUser> userManager,
				CourseSocialMedia.Data.ApplicationDbContext context)
    {
        _logger = logger;

				_context = context;

				_userManager = userManager;
    }

    public async Task OnGetAsync()
    {
			CurrentUser = await _userManager.GetUserAsync(User);

			Posts = _context.Posts.Include(p => p.Uploader).Include(p => p.UserLikes).OrderByDescending(p => p.CreatedAt).ToList();
    }
}
