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
    public class IndexModel : PageModel
    {
        private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

        public IndexModel(CourseSocialMedia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationRole> ApplicationRole { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ApplicationRole = await _context.ApplicationRole.ToListAsync();
        }
    }
}
