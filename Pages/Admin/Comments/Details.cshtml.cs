using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseSocialMedia.Data;
using CourseSocialMedia.Models;

namespace CourseSocialMedia.Pages.Admin.Comments
{
    public class DetailsModel : PageModel
    {
        private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

        public DetailsModel(CourseSocialMedia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Comment Comment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                Comment = comment;
            }
            return Page();
        }
    }
}
