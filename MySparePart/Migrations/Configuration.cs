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
                        new Part {Name="Doorknob Speaker",  ItemPostDate=DateTime.Now, Description="SUCTION CUP BLUETOOTH SPEAKER" , ShippingSize="medium", Quanity=4, PartNumber="95230P1", ImagePath="http://www.sciplus.com/productImages/photo/250x350/56503.jpg" },
                        new Part {Name="Steel Balls", ItemPostDate=DateTime.Now, Description="You pick the 1/2, 5/8, 13/16 or 31/32 dia." , ShippingSize="Small", Quanity=3, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/photo/250x350/SB006.jpg" },
                        new Part {Name="Solder Station", ItemPostDate=DateTime.Now, Description="continuously variable power between 5-40W, a 1.5mm pointed tip thin enough to use on surface-mounted components, a 4-foot cord, padded grip, iron holder, built-in cleaning sponge, and a stand-alone controller with a 5-1/2 x 4-1/2 footprint and a power switch." , ShippingSize="Small", Quanity=10, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/sketch/250x350/48254.jpg" },
                        new Part {Name="Bridge Rectifier", ItemPostDate=DateTime.Now, Description="1-1/8 square x 7/16 thick, with (4) lug terminals. It is rated at 600 volts and 35 amps max" , ShippingSize="Small", Quanity=10, PartNumber="KBPC 3506", ImagePath="http://www.sciplus.com/productImages/photo/500x500/22574.jpg" },
                        new Part {Name="Thermal Fuse",  ItemPostDate=DateTime.Now, Description="Rated for 10A at 250VAC, these normally closed thermal fuses will pop at 128ºC or 262ºF. The fuses themselves are 1/2 long but yours will be wired into leads of assorted lengths, because they were betooken out of coffeemakers of some sort" , ShippingSize="Small", Quanity=1, PartNumber="40701P5", ImagePath="http://www.sciplus.com/productImages/photo/250x350/49707.jpg" },
                        new Part {Name="Dot-Matrix Chip",  ItemPostDate=DateTime.Now, Description="Orange and green glow the (40) 3/16 dia LEDs in the 5 x 8 dot-matrix grid. Housing measures 2-3/8 " , ShippingSize="Small", Quanity=4, PartNumber="41297P1", ImagePath="http://www.sciplus.com/productImages/photo/150x150/50905.jpg" },
                        new Part {Name="Springs Lots of springs", ItemPostDate=DateTime.Now, Description="No large ones, but (101) amazingly assorted small extension, compression and torsion springs -- most, but not all, 1 to 2 long. Assorted lengths, assorted widths, assorted finishes, asorta handy bag of replacement parts to have around the house." , ShippingSize="medium", Quanity=30, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/photo/250x350/4106.jpg" },
                        new Part {Name="Solar Panel", ItemPostDate=DateTime.Now, Description="This 6VDC 50mA solar cell module is perfect for science fairs. Measures 4 x 2-1/2 x 5/16 thick with a pair of 6 leads" , ShippingSize="Small", Quanity=10, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/photo/250x350/55809.jpg" },
                        new Part {Name="piezoelectric disc", ItemPostDate=DateTime.Now, Description="NThis pre-wired piezoelectric disc measures 13/16 dia with tinned 1-1/2 leads" , ShippingSize="Small", Quanity=10, PartNumber="42203P3", ImagePath="http://www.sciplus.com/productImages/photo/150x150/51310.jpg" },
                        new Part {Name="LCDs",  ItemPostDate=DateTime.Now, Description="Liquid Crystal Displays removed from working equipment, random" , ShippingSize="Small", Quanity=1, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/photo/150x150/38868.jpg" },
                        new Part {Name="Electrolytic Capacitors",  ItemPostDate=DateTime.Now, Description="Ten dozen, to be exact. Our package of 120 radial lead electrolytic capacitors comprises: (15) each of 1uF, 2.2uF, 4.7uF, 10uF, and 22uF at 50V, (15) each of 47uF and 100uF at 25V, and (5) each at 220uF, 470uF and 1000uF at 25V" , ShippingSize="medium", Quanity=5, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/photo/250x350/44877.jpg" },
                        new Part {Name="Solid State Buzzer", ItemPostDate=DateTime.Now, Description="solid-state buzzer is a diminutive 9/16 x 3/32 x 1-1/4 but it buzzes along at 8,000 hertz. Rated for 6VDC 20mA, but works fine with as little as 3V." , ShippingSize="Small", Quanity=10, PartNumber="92825P1", ImagePath="http://www.sciplus.com/productImages/photo/150x150/41063.jpg" },
                        new Part {Name="Transformer", ItemPostDate=DateTime.Now, Description="step-down transformer has a 12V 0.7A secondary and primary taps at 220, 110, and 48V (!). Use black and brown for 110V input. Measures 2 x 1-7/8 x 1-5/8 with a pair of 3/16 ID mounting wings." , ShippingSize="Small", Quanity=10, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/photo/250x350/54615.jpg" },
                        new Part {Name="Remote Control Outlet", ItemPostDate=DateTime.Now, Description="From the Newstar company, it includes instructions, which a clever person like yourself may be able to use to actually make it work" , ShippingSize="Large", Quanity=10, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/photo/150x150/46814.jpg" },
                        new Part {Name="Air Flow Sensor",  ItemPostDate=DateTime.Now, Description="This 4 x 3-3/4 x 1-3/4 medical take-out air sensor has (3) ports coming off the main 3-1/8 x 3/4 ID chamber, (2) leading to one sensor and the other leading to a second one, then through circuitry on a mounted PC  board leading to a 10-pin output connector." , ShippingSize="Medium", Quanity=10, PartNumber="N/A", ImagePath="http://www.sciplus.com/productImages/sketch/250x350/51277.jpg" },
                        new Part {Name="Three Phase Motor",  ItemPostDate=DateTime.Now, Description="12VDC 1A 3-coil brushless servo motor with 36 steps per revolution was for a printe" , ShippingSize="Large", Quanity=2, PartNumber="Samsung P/N 02914900", ImagePath="http://www.sciplus.com/productImages/photo/150x150/49727.jpg" },
                        new Part {Name="Balistic Panel Meter", ItemPostDate=DateTime.Now, Description="Max 5V" , ShippingSize="Large", Quanity=10, PartNumber="NFT98934", ImagePath="http://www.sciplus.com/productImages/photo/150x150/50695.jpg" },
                        new Part {Name="Solenoid Valve", ItemPostDate=DateTime.Now, Description="3-way, 120VAC refrigeration valve from Ranco has (3) 6 copper tubes on the valve stem controlled by solenoid action, which opens and closes ports to each tube" , ShippingSize="Small", Quanity=10, PartNumber="Ranco part # 1122030-1071", ImagePath="http://www.sciplus.com/productImages/photo/150x150/53325.jpg" },
                        new Part {Name="Relay", ItemPostDate=DateTime.Now, Description="little lower-power relay from Kest Manufacturing. Measures 13/16 x 3/8” x 7/16. Load contacts are rated for 125VAC 1A or 30VDC 2A. Dual sets of NO/NC contacts" , ShippingSize="Medium", Quanity=10, PartNumber="KS2E-M-DC12", ImagePath="http://www.sciplus.com/productImages/photo/250x350/RE017.jpg" },
                        new Part {Name="Impulse Counter",  ItemPostDate=DateTime.Now, Description="5-digit resetable counter" , ShippingSize="Small", Quanity=2, PartNumber="41237P1", ImagePath="http://www.sciplus.com/productImages/photo/150x150/50734.jpg" }
                    };

          context.Parts.AddOrUpdate(p => p.Name, Parts);
           

            //userManager.Create(user, "123123");
            //userManager.AddToRole(user.Id, "");
        }
    }
}
