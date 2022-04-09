using System;
using Newtonsoft.Json;

namespace First_Try.Models
{
    public class GetIssuesForSprintResponse
    {

        public Issue[] Issues { get; set; }
    }

    public class Issue
    {
        public string Key { get; set; }
        public Fields Fields { get; set; }
    }

    public class Fields
    {
        public string Summary { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Reporter Reporter { get; set; }
        public Type Type { get; set; }
    }

    public class Status
    {
        public string Name { get; set; }
    }

    public class Priority
    {
        public string Name { get; set; }
    }

    public class Reporter
    {
        public string Name { get; set; }
    }
    public class Type
    {
        public string Name { get; set; }
    }

}

