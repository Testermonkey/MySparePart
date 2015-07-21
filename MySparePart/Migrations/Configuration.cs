namespace MySparePart.Migrations {
    using MySparePart.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MySparePart.Models.ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MySparePart.Models.ApplicationDbContext context) {
            //          var userStore = new UserStore<ApplicationUser>(context);
            //          var userManager = new ApplicationUserManager(userStore);
            //          var roleStore = new RoleStore<IdentityRole>(context);
            //          var roleManager = new ApplicationRoleManager(roleStore);

            //          // Create security roles
            //          // Admin role
            //          if (!roleManager.RoleExists("Admin")) {
            //              roleManager.Create(new IdentityRole("Admin"));
            //          }

            //          // PwrUser role
            //          if (!roleManager.RoleExists("PwrUser")) {
            //              roleManager.Create(new IdentityRole("PwrUser"));
            //          }

            //          // AuthUser role
            //          if (!roleManager.RoleExists("AuthUser")) {
            //              roleManager.Create(new IdentityRole("AuthUser"));
            //          }

            //          // Guest Role
            //          if (!roleManager.RoleExists("Guest")) {
            //              roleManager.Create(new IdentityRole("Guest"));
            //          }

            ////Part seed some seed data


            //if (!userManager.Users.Any(u => u.UserName == "foo@bar.com")) {
            //    var user = new ApplicationUser() {
            //        FirstName = "Alex",
            //        LastName = "Underwood",
            //        Email = "foo@bar.com.com",
            //        EmailConfirmed = true,
            //        PhoneNumber = "4257707387",
            //Blogs = new List<Blog> {
            //    new Blog {BlogText="Hack up furballs loves cheesat him at a ", BlogTitle = "Cats Rule", BlogModifiedTimeStamp = DateTime.Now, BlogTimeStamp=DateTime.Now},
            //    new Blog {BlogText = "Sink him! I never look at him at all;.", BlogTitle = "Call me fishy", BlogModifiedTimeStamp = DateTime.Now, BlogTimeStamp=DateTime.Now},
            //    new Blog {BlogText = "Bacon ipsum dolor amet short ribs por ", BlogTitle = "Bacon Anyone?", BlogModifiedTimeStamp = DateTime.Now, BlogTimeStamp=DateTime.Now},
            //    new Blog {BlogText = "Zombie ipsum reversus ab viral inferno", BlogTitle = "Brains?", BlogModifiedTimeStamp = DateTime.Now, BlogTimeStamp=DateTime.Now}
            //},
            var Parts = new Part[]{
                        new Part {Name="THERMAL FUSE",  ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category= "Capacitor" },
                        new Part {Name="Infrared Encoder", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                        new Part {Name="EMI Filter", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Resistor" },
                        new Part {Name="Air Flow Sensor", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                        new Part {Name="Vacuum Sensor",  ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                         new Part {Name="THERMAL FUSE",  ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category= "Capacitor" },
                        new Part {Name="Infrared Encoder", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                        new Part {Name="EMI Filter", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Resistor" },
                        new Part {Name="Air Flow Sensor", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                        new Part {Name="Vacuum Sensor",  ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                             new Part {Name="THERMAL FUSE",  ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category= "Capacitor" },
                        new Part {Name="Infrared Encoder", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                        new Part {Name="EMI Filter", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Resistor" },
                        new Part {Name="Air Flow Sensor", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                        new Part {Name="Vacuum Sensor",  ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                             new Part {Name="THERMAL FUSE",  ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category= "Capacitor" },
                        new Part {Name="Infrared Encoder", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                        new Part {Name="EMI Filter", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Resistor" },
                        new Part {Name="Air Flow Sensor", ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" },
                        new Part {Name="Vacuum Sensor",  ItemPostDate=DateTime.Now, Description="New Axial .01uf 5VDC 10% 20" , ShippingSize="Small", Quanity=10, PartNumber="N/A", Category="Capacitor" }
                    };

          context.Parts.AddOrUpdate(p => p.Name, Parts);
           

            //userManager.Create(user, "123123");
            //userManager.AddToRole(user.Id, "");
        }
    }
}
