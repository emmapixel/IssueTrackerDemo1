using Microsoft.EntityFrameworkCore;
using trackingIssues.Data;

// This is the database schema using migrations. 

var builder = WebApplication.CreateBuilder(args);

// Register services for dependency injection.
builder.Services.AddRazorPages();

// Register the DbContext and configure it so it can use sqlite.
// This connection sting to the database is a path to a file.
// The database will be located in the path. 
// It has the name of Issue.db.
builder.Services.AddDbContext<IssueDbContext>(o => o.UseSqlite("filename=Data/Database/Issue.db"));

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
