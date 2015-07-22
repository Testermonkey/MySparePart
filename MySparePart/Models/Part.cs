using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySparePart.Models {
    public class Part {
        public int Id { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime ItemPostDate { get; set; }
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Part name required")]
        [StringLength(50, ErrorMessage = "Less then 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description required")]
        [StringLength(500, ErrorMessage = "Less then 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quanity required")]
        public int Quanity { get; set; }

        public string PartNumber { get; set; }

        public string ShippingSize { get; set; }

        public bool PartIsHidden { get; set; }

        public bool PartIsLocked { get; set; }

        public bool PartIsDeleted { get; set; }

        public string Category { get; set; }

        public ICollection<PartRequest> PartRequest { get; set; } // For request tracking
        public Part() {
            this.PartRequest = new List<PartRequest>();
        }
    }
}