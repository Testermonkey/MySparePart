using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySparePart.Models {
    public class PartRequest {
        public int Id { get; set; }

        public ApplicationUser PartOwner { get; set; }

        public ApplicationUser RequestUser { get; set; }

        public DateTime RequestTimeStamp { get; set; }

        public DateTime RequestMailedTimeStamp { get; set; }

        public bool RequestEmailSent { get; set; }

        public bool RequestMailed { get; set; }

        public int ItemId { get; set; }
    }
}