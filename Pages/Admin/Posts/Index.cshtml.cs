using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseSocialMedia.Data;
using CourseSocialMedia.Models;

namespace CourseSocialMedia.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

        public IndexModel(CourseSocialMedia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.Include(p => p.Uploader).Include(p => p.UserLikes).ToListAsync();
        }
    }
}
