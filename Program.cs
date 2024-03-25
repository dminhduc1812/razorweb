using Cs_razorweb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; // Import this namespace for accessing Configuration

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// AddDbContext using the Configuration object to access connection strings
builder.Services.AddDbContext<MyBlogContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("MyBlogContext"))); // Use builder.Configuration

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

/*
    CREATE, READ, UPDATE, DELETE (CRUD)
    
    dotnet aspnet-codegenerator razorpage -m Cs_razorweb.Models.Article -dc Cs_razorweb.Models.MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries
    dotnet aspnet-codegenerator razorpage -m Cs_razorweb.Models.Article -dc Cs_razorweb.Models.MyBlogContext -outDir Pages/Blog --referenceScriptLibraries
   
*/