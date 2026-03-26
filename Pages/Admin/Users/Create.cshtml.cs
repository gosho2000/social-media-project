using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseSocialMedia.Data;
using CourseSocialMedia.Models;

namespace CourseSocialMedia.Pages.Admin.Users
{
    public class CreateModel : PageModel
    {
        private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

        public CreateModel(CourseSocialMedia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(ApplicationUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
