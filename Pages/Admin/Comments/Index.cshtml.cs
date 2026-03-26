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
    public class IndexModel : PageModel
    {
        private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

        public IndexModel(CourseSocialMedia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Comment = await _context.Comments
                .Include(c => c.Post)
                .Include(c => c.User).ToListAsync();
        }
    }
}
