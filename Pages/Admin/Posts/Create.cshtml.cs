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

namespace CourseSocialMedia.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

				private readonly UserManager<ApplicationUser> _userManeger;

				public SelectList Users { get; set; }

        public CreateModel(CourseSocialMedia.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;

						_userManeger = userManager;

						
        }

        public IActionResult OnGet()
        {
					ICollection<ApplicationUser> users = _userManeger.Users.ToList();

					// Users = users.Select(u => new SelectListItem
					// 		{
					// 			Value = u.Id,
					// 			Text = u.Email
					// 		}).ToList();

					
					Users = new SelectList(_context.Users, "Id", "Email");

            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
							foreach (var key in ModelState.Keys)
							{
								var state = ModelState[key];
								foreach (var error in state.Errors)
								{
									Console.WriteLine($"{key}: {error.ErrorMessage}");
								}
							}
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
