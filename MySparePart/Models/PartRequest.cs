using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySparePart.Models {
    public class PartRequest {
        public int Id { get; set; }
        public string OwnerEmail { get; set; }
        public string RequestorEmail { get; set; }
        public DateTime? RequestTimeStamp { get; set; }
        public DateTime? RequestMailedTimeStamp { get; set; }
        public bool? RequestEmailSent { get; set; }
        public bool? RequestMailed { get; set; }
        public int ItemId { get; set; }
    }
}