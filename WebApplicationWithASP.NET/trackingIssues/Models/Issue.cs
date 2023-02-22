using System.ComponentModel.DataAnnotations;
using System.Globalization;

// This is our Issue model.

namespace trackingIssues.Models
{
    public class Issue
    {
        // Primary key property.
        // The first step to validating data is to decorate properties with built-in validation attributes.
        public uint Id { get; set; }

        [Required]
        [StringLength(100)]

        // Title has the default value Empty.
        public string Title { get; set; } = string.Empty;

        // Description has the default value Empty.

        [Required]
        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        // An issue has a type that will be represented by a enum named issue.
        public IssueType IssueTypes { get; set; }

        /* An issue can also have a priority that will be represented by a
           enum called Priority, that we generate lower down. */
        public Priority Priorities { get; set; }

        // An issue also has a DateTime property with the name Created.
        // Created represents the date the issue was created.
        public DateTime Created { get; set; }

        // An issue also has a Datetime property with the name Completed.
        // Completed represents the date the issue was completed.
        // This property will contain either null (pending) or a datetime when it´s been resolved.
        public DateTime? Completed { get; set; }

        // Generating the enum IssueType.
        public enum IssueType
        {
            // The possible values are.
            Feature,
            Bug,
            Documentation
        }

        // Generating the enum Priority.
        public enum Priority
        {
            Low,
            Medium,
            High
        }
    }
}
