
// Declaring the data context for injection inside the DetailModel constructor.

/* 
   In the OnGet method we use the data context to fetch a single issue based on the id.
   and we assign it to an issue property.
   When the method is executed the model-binder will populate the parameter with the id 
   in the route.
*/

/* 
   The OnGetResolve method is called a named handler. It takes an argument of a specific issue.
   It could be executed in response to a http get request.
   To resolve the issue we first fetch the issue we want to update.
   Then we set the completed property to the current date time.
   Last we save the changes to the database.
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using trackingIssues.Data;
using trackingIssues.Models;

namespace trackingIssues.Pages.Issues
{
    public class DetailModel : PageModel
    {
        private readonly IssueDbContext _context;
        public DetailModel(IssueDbContext context) => _context = context;

        public async Task<IActionResult> OnGetResolve(uint id)
        {
            var issueToUpdate = _context.Issues.SingleOrDefault(i => i.Id == id);
            if (issueToUpdate == null) return RedirectToPage("../Index");

            issueToUpdate.Completed = DateTime.Now;

            _context.Update(issueToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("../Index");
        }

        public Issue? Issue { get; set; }

        public async void OnGet(uint id)
        {
            Issue = await _context.Issues.FindAsync(id);
        }
    }
}
