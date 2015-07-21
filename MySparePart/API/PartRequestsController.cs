using MySparePart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Http;

namespace MySparePart.API {
    public class PartRequestsController : ApiController {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public PartRequest GetPartRequest(int id) {         //Details
            return _db.PartRequests.Find(id);
        }

        public IList<PartRequest> GetPartRequests() {       //List
            var currentUser = new ApplicationUser();
            currentUser.Id = HttpContext.Current.User.Identity.GetUserId();
            //get this sorted

            return _db.PartRequests.ToList();
        }

      public HttpResponseMessage PostPartRequests(PartRequest partRequest) { //Create Edit
            if (ModelState.IsValid) {
                if (partRequest.Id == 0) { //check if new request or an edit
                    _db.PartRequests.Add(partRequest);
                    partRequest.RequestTimeStamp = DateTime.Now;
                    partRequest.RequestUser.Id = HttpContext.Current.User.Identity.GetUserId();
                    //   partRequest.PartOwner.Email = part.partOwner.Email;
                    _db.SaveChanges();
                }
                else {
                    var original = _db.PartRequests.Find(partRequest.Id);
                    original.PartOwner = partRequest.PartOwner;
                    original.RequestUser = partRequest.RequestUser;
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

                // [Authorize]
        public void DeletePartRequest(int id) {
            var original = _db.PartRequests.Find(id);
            _db.PartRequests.Remove(original);
            _db.SaveChanges();
        }

    }
}
