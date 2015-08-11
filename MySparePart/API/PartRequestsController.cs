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
    public class PartRequestsController : ApiController {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public PartRequest GetPartRequest(int id) {         //Details
            return _db.PartRequests.Find(id);
        }

        public IList<PartRequest> GetPartRequests() {       //List
            var currentUser = new ApplicationUser();
            currentUser.Id = HttpContext.Current.User.Identity.GetUserId();
            var user = this.User.Identity as ClaimsIdentity;

            if (user.HasClaim(ClaimTypes.Role, "isAdmin")) {   // show admin everything
                return _db.PartRequests.ToList();
            }
            else { //show user only their own request
                return _db.PartRequests.Where(n => n.OwnerEmail == currentUser.Email).Where(n => n.RequestorEmail == currentUser.Email).ToList();
            }
        }


        public HttpResponseMessage PostPartRequests(PartRequest partRequest) { //Create Edit
            if (ModelState.IsValid) {
                if (partRequest.Id == 0) { //check if new request or an edit
                    _db.PartRequests.Add(partRequest);
                    partRequest.RequestTimeStamp = DateTime.Now;
                   // partRequest.RequestorEmail = User.Identity.GetUserName(); //currently pulling this from the conttrollers.js 268
                    partRequest.RequestMailedTimeStamp = DateTime.Now;
                    partRequest.RequestEmailSent = true;
                    partRequest.RequestMailed = false;

                    _db.SaveChanges();

                }
                else {
                    //Start - Guard clauses
                    if ( !(HttpContext.Current.User.IsInRole("isAdmin"))) { throw new System.ArgumentException("Cannot edit unless Admin", "original"); };
                    //End - Guard clauses

                    var original = _db.PartRequests.Find(partRequest.Id);
                    original.OwnerEmail = partRequest.OwnerEmail;
                    original.RequestorEmail = partRequest.RequestorEmail;
                    original.RequestTimeStamp = partRequest.RequestTimeStamp;
                    original.RequestEmailSent = partRequest.RequestEmailSent;
                    original.RequestMailed = partRequest.RequestMailed;
                    original.ItemId = partRequest.ItemId;

                    _db.SaveChanges();

                }
                return Request.CreateResponse(HttpStatusCode.Created, partRequest);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

        [Authorize]
        public void DeletePartRequest(int id) {
            var user = this.User.Identity as ClaimsIdentity;
            var original = _db.PartRequests.Find(id);
            //Start - Guard clauses
            if (!(HttpContext.Current.User.IsInRole("isAdmin"))) { throw new System.ArgumentException("Cannot edit unless Admin", "original"); };
            //End - Guard clauses

            if (user.HasClaim(ClaimTypes.Role, "isAdmin")) {   // if admin delete
                _db.PartRequests.Remove(original);
                _db.SaveChanges();
            }

        }
    }
}
