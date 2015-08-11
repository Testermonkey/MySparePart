using MySparePart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Http;
using System.Security.Claims;

namespace MySparePart.API {
    public class PartsController : ApiController {

        //mapping to the Parts Database
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IList<Part> GetParts() {
            var user = this.User.Identity as ClaimsIdentity;
            if (user.HasClaim(ClaimTypes.Role, "isAdmin")) {
                return _db.Parts.ToList(); // show admin everything
            }
            else {
                return _db.Parts.Where(n => n.PartIsHidden == false).Where(n => n.PartIsDeleted ==false).ToList(); // hide deleted and hidden
            }
        }

        [Authorize]  // need to be a user to add / edit part
        public HttpResponseMessage PostParts(Part part) {

            if (ModelState.IsValid) {
                if (part.Id == 0) { // part is new - create new fields
                    _db.Parts.Add(part);
                    part.PartIsLocked = true;
                    part.PartIsDeleted = true;
                    part.PartIsHidden = true;
                    part.ItemPostDate = DateTime.Now;
                    part.OwnerEmail = HttpContext.Current.User.Identity.Name.ToString();  //fix permissions then uncomment
                    _db.SaveChanges();
                }
                else {  // part not new - update fields

                    //Start - Guard clauses
                    if (!(part.OwnerEmail == HttpContext.Current.User.Identity.Name) || !(HttpContext.Current.User.IsInRole("isAdmin"))) { throw new System.ArgumentException("Cannot edit unless partOwner or Admin", "original"); };
                    if (HttpContext.Current.User.Identity.IsAuthenticated) { throw new System.ArgumentException("Cannot edit unless authenticated", "original"); };
                    if (part.PartIsHidden) { throw new System.ArgumentException("Cannot eidt hidden part", "original"); };
                    if (part.PartIsDeleted) { throw new System.ArgumentException("Cannot edit deleted part", "original"); };
                    //End - Guard clauses

                    var original = _db.Parts.Find(part.Id);
                    original.Name = part.Name;
                    original.PartNumber = part.PartNumber;
                    original.Description = part.Description;
                    original.Quanity = part.Quanity;
                    original.ShippingSize = part.ShippingSize;
                    // original.Category = part.Category; //not in use
                    original.PartIsDeleted = part.PartIsDeleted;
                    original.PartIsHidden = part.PartIsHidden;
                    original.PartIsLocked = part.PartIsLocked;
                    _db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.Created, part);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

        public Part GetPart(int id) { //Get one Part
            return _db.Parts.Find(id);
        }


        [Authorize]
        public void DeletePart(int id) {
            var user = this.User.Identity as ClaimsIdentity;
            // Guard clause
            if (!(HttpContext.Current.User.IsInRole("isAdmin"))) { throw new System.ArgumentException("Cannot delete unless Admin", "original"); };

            if (user.HasClaim(ClaimTypes.Role, "isAdmin")) {
                var original = _db.Parts.Find(id);
                _db.Parts.Remove(original);
                _db.SaveChanges();
            }
        }
       
        [Authorize]
        public void DeleteAll() {   //use with caution
            var user = this.User.Identity as ClaimsIdentity;
            // Guard clause
            if (!(HttpContext.Current.User.IsInRole("isAdmin"))) { throw new System.ArgumentException("Cannot delete unless Admin", "original"); };

            if (user.HasClaim(ClaimTypes.Role, "isAdmin")) {
                var DelList = _db.Parts.Where(n => n.PartIsDeleted == true).ToList();
                foreach (Part part in DelList) {
                    _db.Parts.Remove(part);
                }
                _db.SaveChanges();
            }
        }

        public void clientDeletePart(int id) {
            var original = _db.Parts.Find(id);
            original.PartIsDeleted = true;
            original.PartIsHidden = true;
            _db.SaveChanges();
        }
    }
}
