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
    public class PartsController : ApiController {

        private ApplicationDbContext _db = new ApplicationDbContext();


      
        //    //// need to logout/login again to load claims
        //    //var claimsUser = this.User as ClaimsPrincipal;
        //    //var claims = claimsUser.Claims.ToList();

      

        public IList<Part> GetParts() {
            var currentUser = new ApplicationUser();
            currentUser.Id = HttpContext.Current.User.Identity.GetUserId();

            //need to logout/login again to load claims
            //var claimsUser = this.User as ClaimsPrincipal;
            //var claims = claimsUser.Claims.ToList();

            //if (HttpContext.Current.User.IsInRole("Admin")) {
            //    return _db.Query<Part>().ToList();  //Change these to return views with querys
            //}
            //if (HttpContext.Current.User.IsAuthenticated()) {
            //    return _db.Query<Part>().Where(n => n.PartIsHidden == false).ToList();
            //}
            //else {
            //    return _db.Query<Part>().Where(n => n.PartIsHidden == false).Where(n => n.PartOwner.Id != currentUser.Id.ToString()).ToList();
            //}
            return _db.Parts.ToList();
        }


        //[Authorize(Users='bob')]
        //[Authorize(Roles='bob')]
        // [Authorize]

        public HttpResponseMessage PostParts(Part part) {

            if (ModelState.IsValid) {
                if (part.Id == 0) {                 // part is new - create new fields
                    _db.Parts.Add(part);
                    part.PartIsLocked = false;
                    part.PartIsDeleted = false;
                    part.PartIsHidden = false;
                    part.ItemPostDate = DateTime.Now;
                    part.PartOwner.UserName = HttpContext.Current.User.Identity.Name;
                    _db.SaveChanges();
                }
                else {                              // part not new - update fields
                    //convert to unit tests
                    //add a try catch
                    //Guard clauses
                    //if (!(part.PartOwner.UserName == HttpContext.Current.User.Identity.Name) || !(HttpContext.Current.User.IsInRole("Admin"))) { throw new System.ArgumentException("Cannot edit unless partOwner or Admin", "original"); };
                    //if (HttpContext.Current.User.Identity.IsAuthenticated) { throw new System.ArgumentException("Cannot edit unless authenticated", "original"); };
                    //if (part.PartIsHidden) { throw new System.ArgumentException("Cannot eidt hidden part", "original"); };
                    //if (part.PartIsDeleted) { throw new System.ArgumentException("Cannot edit deleted part", "original"); };
                    var original = _db.Parts.Find(part.Id);
                    original.Name = part.Name;
                    original.PartNumber = part.PartNumber;
                    original.Description = part.Description;
                    original.Quanity = part.Quanity;
                    original.ShippingSize = part.ShippingSize;
                    original.Category = part.Category;
                    _db.SaveChanges();
                }
             return Request.CreateResponse(HttpStatusCode.Created, part);
            }
           return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

        public Part GetPart(int id) {
            return _db.Parts.Find(id);
        }

        // [Authorize]
        public void DeletePart(int id) {
            var original = _db.Parts.Find(id);
            _db.Parts.Remove(original);
            _db.SaveChanges();
        }

        public void clientDeletePart(int id) {
            var original = _db.Parts.Find(id);
            original.PartIsDeleted = true;
            original.PartIsHidden = true;
            _db.SaveChanges();
        }

        //[Authorize]
       // public void RemoveIsDeleted(Parts parts);

        //public IList<Part> SortRequestsByOwner(string user) {
        //    return _db.Query<Part>().Where(n => n.PartOwner.UserName == user).ToList();
        //    //Show all request by owner
        //    //only for PwrUser/Admin
        //}

        //public IList<Part> SortPartsByOwner(string user) {
        //    return _db.Query<Part>().Where(n => n.PartOwner.UserName == user).ToList();
        //    //Show all request by owner
        //    //only for PwrUser/Admin
        //}
        //public IList<Part> SortPartsByCatagory(string catagory) {
        //    return _db.Query<Part>().Where(n => n.Catagory == catagory).Where(n => n.PartIsHidden == false).ToList();
        //    //Show all parts by catagory
        //    // all users
        //}

        //public IList<Part> TitleSearchPartsByKeyWord(string keyword) {
        //    return _db.Query<Part>().Where(n => n.Name.Contains(keyword)).Where(n => n.PartIsHidden == false).ToList();
        //    //Search parts list by word search
        //    // all users
        //}

        //public IList<Part> DescriptionSearchPartsByKeyWord(string keyword) {
        //    return _db.Query<Part>().Where(n => n.Description.Contains(keyword)).Where(n => n.PartIsHidden == false).ToList();
        //    //Search parts list by word search
        //    // all users
        //}
        //public bool PartRequestSendEmail(PartRequest partRequest) {

        //    if (partRequest.RequestMailed) {
        //        //send mail for request mailed

        //        return true;
        //    }
        //    else {
        //        // it is a new part request
        //        // send mail for new request
        //        // mail goes to both partOwner and RequestUser
        //    }
        //    return true;
        //}
    }
}
