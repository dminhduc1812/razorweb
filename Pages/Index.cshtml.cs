﻿using Cs_razorweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cs_razorweb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly MyBlogContext _myBlogContext;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myContext)
    {
        _logger = logger;
        _myBlogContext = _myContext;
    }

    public void OnGet()
    {
        var posts = (from a in _myBlogContext.articles
            orderby a.Created descending
            select a).ToList();

        ViewData["posts"] = posts;
    }
}