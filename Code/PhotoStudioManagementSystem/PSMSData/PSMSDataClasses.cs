//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace PSMSData
//{
//    public class OpenPDNConnector
//    {
//        public PhotoEditInfo editPhoto(PhotoInfo photo, PhotoEditType type)
//        {
//            throw new NotImplementedException();
//        }
//    }
//    public class PSMSController
//    {
//        public EmployeeManager employeeController;
//        public CustomerManager customerController;
//        public List<ReportInfo> reports;
//        public List<PaymentInfo> payments;
//    }

//    public class EmployeeManager
//    {
//        public List<EmployeeInfo> employees;
//    }

//    public class CustomerManager
//    {
//        public List<CustomerInfo> customers;
//    }

//    public class PhotoEditController
//    {
//        public List<PhotoEditInfo> edits;
//        public OpenPDNConnector editAPIs;
//    }

//    public enum PostType
//    {
//        Technician,
//        Admin,
//        Owner
//    }

//    public class EmployeeInfo
//    {
//        public string id { get; set; }
//        public string name { get; set; }
//        public string address { get; set; }
//        public string contact { get; set; }
//        public PostType postType { get; set; }
//        public DateTime doj { get; set; }
//        public string department { get; set; }
//    }

//    public class CustomerInfo
//    {
//        public string id { get; set; }
//        public string name { get; set; }
//        public string address { get; set; }
//        public string contact { get; set; }
//        public List<PhotoInfo> photos;
//        public List<PaymentInfo> payements;
//    }

//    public class PaymentInfo
//    {
//        public string id { get; set; }
//        public string name { get; set; }
//        public string customerId { get; set; }
//        public double amount { get; set; }
//        public DateTime dop { get; set; }
//    }
//    public class PhotoInfo
//    {
//        string name;
//        string softwareUsedForCapture;
//        EmployeeInfo technicianTaken;
//        string ImageFile;
//        double size;
//        DateTime dateTaken;
//        List<PhotoEditInfo> edits;
//    }

//    public enum PhotoEditType
//    {
//        Rotate,
//        Crop,
//        Stretch,
//        Brighten,
//        Sepia
//    }

//    public class PhotoEditInfo
//    {
//        string name;
//        string softwareUsedtoEdit;
//        EmployeeInfo technicianEdited;
//        string OriginalImageFile;
//        string EditedImageFile;
//        double size;
//        DateTime dateEdited;
//        PhotoEditType type;
//    }

//    public enum ReportType
//    {
//        Single,
//        Daily,
//        Weekly,
//        Monthly,
//        Quarterly,
//        Yearly
//    }

//    public class ReportInfo
//    {
//        public string id { get; set; }
//        public DateTime date { get; set; }
//        public ReportType type { get; set; }
//        public string description { get; set; }
//    }
//}
