// This is our data context. It is the object that interacts with the database.

using Microsoft.EntityFrameworkCore;
using trackingIssues.Models;

namespace trackingIssues.Data
{
    // This class must inherit from the DbContext class. (Import the framework for it).
    public class IssueDbContext : DbContext
    {
        // This is our constructor that has one parameter from DbContextOptions called options.
        // This will allow us to configure the Db context for dependency injection.
        public IssueDbContext(DbContextOptions options):base(options)
        {

        }

        // This property is a Db set of Issue.
        // The property will allow us to interact with issues in the database.
        public DbSet<Issue> Issues { get; set; }

        internal Task AllAsync<T>()
        {
            throw new NotImplementedException();
        }
    }
}
