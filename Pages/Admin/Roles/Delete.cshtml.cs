using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseSocialMedia.Data;
using CourseSocialMedia.Models;

namespace CourseSocialMedia.Pages.Admin.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

        public DeleteModel(CourseSocialMedia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationrole = await _context.ApplicationRole.FirstOrDefaultAsync(m => m.Id == id);

            if (applicationrole == null)
            {
                return NotFound();
            }
            else
            {
                ApplicationRole = applicationrole;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationrole = await _context.ApplicationRole.FindAsync(id);
            if (applicationrole != null)
            {
                ApplicationRole = applicationrole;
                _context.ApplicationRole.Remove(ApplicationRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
