using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using trackingIssues.Data;
using trackingIssues.Models;

// This page contains C# code to handle page events.

/* We want to use the Db Context to fetch all the issues from the database -
   and make them available in the view. */

namespace trackingIssues.Pages
{
    public class IndexModel : PageModel
    {
        private IssueDbContext _context;

        // Declare the Db context in the constructor.
        // This injects it at run time by the dependency injection container.
        public IndexModel(IssueDbContext context) => _context = context;

        // Here we load the issues from the database with the OnGet handler method.
        // It's a method executed in response to an http request.
        /* By convention an http request is mapped to an angular method in which the name -
           starts with the On and then ends with a http verb like for example: Get. 
           It is executed when the page is requested. This is therefore a good place -
           to initialize the state of the page. */
        public async Task OnGetAsync()
        {
            /* Here we want to load the pending issues that have the Completed property -
               set to null. We also want to sort them based on the Created property. 
               When the page loads the issues property will be filled with issues. */
            Issues = await _context.Issues
                .Where(i => i.Completed != null)
                .OrderByDescending(i => i.Created)
                .ToListAsync();
        }

        // Property that will hold all the issues with type IEnumerable of issue.
        // We set the value to Empty so we don't need to check for null when using it.
        public IEnumerable<Issue> Issues { get; set; } = Enumerable.Empty<Issue>();
    }
}