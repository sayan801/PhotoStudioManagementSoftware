using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSMSData
{
    public enum PostType
    {
        Technician,
        Admin,
        Owner
    }

    public class EmployeeInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public PostType postType { get; set; }
        public DateTime doj { get; set; }
        public string department { get; set; }
    }

    public class CustomerInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
    }

    public class PaymentInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string customerId { get; set; }
        public double amount { get; set; }
        public DateTime dop { get; set; }
    }
    public class PhotoInfo
    {
        string name;
        string softwareUsed;
        EmployeeInfo technician;
        string ImageFile;
        double size;
        DateTime timeTaken;
    }

    public enum ReportType
    {
        Single,
        Daily,
        Weekly,
        Monthly,
        Quarterly,
        Yearly
    }

    public class ReportInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public ReportType type { get; set; }
        public string description { get; set; }
    }
}
