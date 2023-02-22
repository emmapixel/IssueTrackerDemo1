using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using trackingIssues.Data;
using trackingIssues.Models;

namespace trackingIssues.Pages.Issues
{
    public class NewModel : PageModel
    {
        private readonly IssueDbContext _context;

        // We need the Db context for saving data.
        public NewModel(IssueDbContext context) => _context = context;

        // We need this method because we submit data using the Post method.
        // Here we perform server-side validation using the model state.
        /* The object will tell us if the model is valid according to the validation attributes -
           we set on the model. If the model is invalid we want to return to the page,
           so the errors can be displayed to the user. */
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            // Update the created property before adding it to the collection.
            Issue.Created = DateTime.Now;
            Issue.Completed = null;

            // We use context to add the issue to the collection.
            await _context.Issues.AddAsync(Issue);

            // Here we invoke safe changes async on the context to propagate changes to the database.
            await _context.SaveChangesAsync();
            
            // After saving the issue redirect the user to the home page.
            // We do this by changing the signature of the method to return an action result.
            return RedirectToPage("../Index");
        }

        // This property will add data submitted in the form.
        // This is possible thanks to model binding. 
        /* In razor pages model binding is the process of taking values from htto requests -
           and mapping them to a handler method parameters or to a property of a page model. 
           We decorate the property with the bind property attribute. */


        [BindProperty]
        public Issue Issue { get; set; }
    }
}
