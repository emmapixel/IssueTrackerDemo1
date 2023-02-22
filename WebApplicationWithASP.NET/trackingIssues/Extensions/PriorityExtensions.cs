using static trackingIssues.Models.Issue;

namespace trackingIssues.Extensions
{
    public static class PriorityExtensions
    {
        /* 
           Add a new method named ToCssClass.
           The goal of this extension method is to return a string representing css classes to use
           in order to display a badge. The method takes a priority enum. 
           The method ToCssClass will look up in the dictionary to find the priority and 
           find the corresponding css classes. 
           We declare a dictionary that will map a priority to some css classes. 

         */

        static readonly Dictionary<Priority, string> _priorityCssClasses = new()
        {
            [Priority.High] = "badge bg-danger",
            [Priority.Medium] = "badge bg-warning text dark",
            [Priority.Low] = "badge bg-success"
        };

        public static string ToCssClass(this Priority priority) => _priorityCssClasses[priority];
    }
}
