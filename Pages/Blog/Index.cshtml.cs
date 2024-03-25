using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cs_razorweb.Models;

namespace Cs_razorweb.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly Cs_razorweb.Models.MyBlogContext _context;

        public IndexModel(Cs_razorweb.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public const int ITEMS_PER_PAGE = 10;
        
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }

        public int countPage { get; set; }

        public async Task OnGetAsync(string SearchString)
        {

            int totalArticle = await _context.articles.CountAsync();
    
            countPage = (int)Math.Ceiling((double)totalArticle / ITEMS_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPage)
                currentPage = countPage;
            
            // Article = await _context.articles.ToListAsync();

            var qr = from a in _context.articles
                orderby a.Created descending 
                select a;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Article = qr.Where(a => a.Title.Contains(SearchString)).ToList();
            }
            else
            {
                Article = await qr.ToListAsync();
            }

            await qr.ToListAsync();
        }
    }
}
