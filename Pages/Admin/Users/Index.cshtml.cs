using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseSocialMedia.Data;
using CourseSocialMedia.Models;

using Microsoft.AspNetCore.Identity;

namespace CourseSocialMedia.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

				private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(CourseSocialMedia.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;

						_userManager = userManager;
        }

        public IList<ApplicationUser> ApplicationUser { get;set; } = default!;

				public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();

        public async Task OnGetAsync()
        {
            ApplicationUser = await _context.Users.ToListAsync();
							// .Join(_context.UserRoles,
							// 	user => user.Id,
							// 	ur => ur.UserId,
							// 	(user, ur) => new { user, ur })
							// 	.Join(_context.Roles, user => user.ur.RoleId, role => role.Id,
							// 			(user, role) => new {
							// 				user, role
							// 			})
							// 	.ToListAsync();

						foreach (ApplicationUser user in ApplicationUser)
						{
							ICollection<string> roles = await _userManager.GetRolesAsync(user);

							Roles[user.Id] = roles?.FirstOrDefault() ?? "None";
						}

        }
    }
}
