using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10203070_PROG7312_POE
{
    public class ReportedIssue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> AttachedFiles { get; set; }

        public ReportedIssue(string location, string category, string description, List<string> attachedFiles)
        {
            Location = location;
            Category = category;
            Description = description;
            AttachedFiles = attachedFiles ?? new List<string>();
        }
    }

}
