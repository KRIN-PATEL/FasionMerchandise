using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Group6_Fashion_Merchandise.Models;

namespace Group6_Fashion_Merchandise.Data
{
    
    public class ProductContext : IdentityDbContext<ApplicationUser>
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Hanes Men’s Ultimate Cotton Heavyweight Pullover Hoodie",
                    Description = "FLEECE TO FEEL GOOD ABOUT - Hanes EcoSmart men's hoodie is made with cotton sourced from American farms.\r\nHOODED DESIGN - Classic fleece hoodie styling featuring a dyed-to-match drawstring for the perfect fit.\r\nUNISEX SIZING - This hooded sweatshirt is designed with a standard men’s fit that also creates an effortless, oversized look for women. Female model is 5'8\" and wearing a size medium.",
                    Price = 49.99M,
                    ImagePath = "/images/Product/Hoodie.jpg",
                    Category = "Men's Wear",
                    StockQuantity = 10
                },
                new Product
                {
                    Id = 2,
                    Name = "MISFAY Women Summer Dresses",
                    Description = "This summer dress for women is made of 90% polyester. The womens dresses is so lightweight, soft, breathable and skin friendly\r\n Summer dresses women trendy 2025 with Sexy V Neck Design,Casual Loose Fit Swing Tank dress, Short sleeve，Button Front , Elastic at Waist，Two Slipt Side Pockets, Above-knee mini dress, High low hem, Beach dress for women, T-shirt dress,Sundress for women, Swing dress, Summer dress, Loose dress",
                    Price = 89.99M,
                    ImagePath = "/images/Product/MISFAY Women Summer Dresses.jpg",
                    Category = "Women's Wear",
                    StockQuantity = 58
                },
                 new Product
                 {
                     Id = 3,
                     Name = "AUSELILY Summer Dress for Women Ruffle Sleeve Button Down Midi Dress A-Line with Pockets",
                     Description = "Material:90% Polyester,10% Spandex.This summer dress for women is super soft,stretchy and lightweight,keep you comfy in summer\r\nFeatures/Design:Ruffle Sleeve,Button Down,V-Neck,Floral Printed,Elegant,Swing,Midi dress,A-Line.Perfect for Spring,Summer,Autumn.The ruffle sleeve sundress would make your arms look more slimmer",
                     Price = 129.99M,
                     ImagePath = "/images/Product/AUSELILY Summer Dress.jpg",
                     Category = "Women's Wear",
                     StockQuantity = 5
                 },
                  new Product
                  {
                      Id = 4,
                      Name = "HOOD CREW Men’s Long Sleeved Plaid Hooded Sweatshirts Patchwork Color Pullover Hoodies with Drawstring",
                      Description = "Made of soft fabrics.This hoodie is not only comfortable and breathable, but also very elastic,the upper body effect is great.\r\n Unique plaid color blocking design(plaid jacquard), long sleeves hoodies with side pockets,pullover with adjustable drawstrings.\r\n Classic casual athletic fit,regular fit,suitable for spring fall and daily sports wear.",
                      Price = 29.99M,
                      ImagePath = "/images/Product/Sweatshirt.jpg",
                      Category = "Men's Wear",
                      StockQuantity = 50
                  },
                  new Product
                  {
                      Id = 5,
                      Name = "Alimens & Gentle Men's Short Sleeve Dress Shirts Wrinkle Free Casual Button Down Shirts with Pocket",
                      Description = "High quality fabric: 62% cotton + 35% polyester + 3% spandex. The casual short sleeve shirts is made of high-quality fabric to make your movement easier; soft, comfortable and breathable; perfect for summer and hot weather\r\nDesign: Short sleeve design, Solid color short sleeve shirt more attractive, button, regular fit dress shirt fits most body types\r\nOccasion: Suitable for many occasions, daily casual/business/concert/date/work/wedding",
                      Price = 59.99M,
                      ImagePath = "/images/Product/Alimen shirt.jpg",
                      Category = "Shirt",
                      StockQuantity = 45
                  },
                  new Product
                  {
                      Id = 6,
                      Name = "COOFANDY Men's Casual Long Sleeve Henley Shirts Cotton Linen Premium Beach T-Shirt",
                      Description = "Soft and comfortable long sleeve henley shirts, lightweight and breathable, cotton and linen fabric make you feel terrific all day long.\r\nCasual beach t shirt, 4-button placket, button closure, long sleeve (can be rolled up), henley neck, showing casual and natural style.\r\nThe henley long sleeve casual t-shirt is very versatile. It looks great with shorts, jeans, beach pants and trousers. Also can match jackets and knitted cardigans in cold weather.",
                      Price = 99.99M,
                      ImagePath = "/images/Product/shirt.jpg",
                      Category = "Shirt",
                      StockQuantity = 75
                  },
                  new Product
                  {
                      Id = 7,
                      Name = "Sailwind Mens Henley T-Shirt Short Sleeve Cotton Casual Shirt",
                      Description = "Textured fabric that's soft, comfortable & light\r\nSlim fit summer cotton shirts.Three buttons design.It's a good summer casual t-shirt.\r\nUS size.Model in size M.Model information(Height:6'1\",Weight:183Ib,Chest:39\")\r\nSuit for casual occasions work, sports, holiday, beach and daily wear etc.It is a gift that will satisfy your son, husband, father and friends.\r\nMachine-Wash.Do Not Bleach",
                      Price = 119.99M,
                      ImagePath = "/images/Product/t-shirt.jpg",
                      Category = "T-Shirt",
                      StockQuantity = 35
                  },
                  new Product
                  {
                      Id = 8,
                      Name = "Placket Cotton Shirt Summer Fashion Breathable Basic T-Shirts",
                      Description = "Material: Solid color: cotton, heather color: 65% cotton and 35% polyester; Stretchy and comfortable, The fabric is high quality, light but not thin,perfect for daily casual wearing.\r\nClassic Henley Style: Three button henley closure, easy on and off, modify the shape of your neck. Enhance the comfort of wearing.\r\nRibbed Neckline: The neckline and cuff stitches are neat, and the ribbed design is more resistant to deformation, fashionable than the ordinary design.",
                      Price = 29.99M,
                      ImagePath = "/images/Product/cotton shirt.jpg",
                      Category = "T-Shirt",
                      StockQuantity = 23,
                  },
               new Product
               {
                   Id = 9,
                   Name = "Amazon Essentials Mens Slim-Fit Wrinkle-Resistant Flat-Front Chino Pant",
                   Description = "SLIM FIT: Fitted through hip and thigh with tapered leg. Sits below the waist.\r\nWRINKLE-RESISTANT CHINO: Easy care cotton-blend chino fabric with a wrinkle-resistant finish and peached hand-feel. These pants are not wrinkle-free, but treated for ease of care with a wrinkle-resistant finish.\r\nCLASSIC STYLE: Flat-front chino details with a versatile yet tailored look and all-day comfort.",
                   Price = 29.80M,
                   ImagePath = "/images/Product/pants.jpg",
                   Category = "Pant",
                   StockQuantity = 13,
               },
               new Product
               {
                   Id = 10,
                   Name = "Fruit of the Loom Mens Eversoft Fleece Sweatpants & Joggers",
                   Description = "Open Bottom Sweatpants\r\nEverSoft ring spun cotton provides premium softness wash after wash\r\nWicking & odor protection\r\nElastic quick cord for adjustable waist with deep pockets to keep items secure\r\nDouble-needle stitching on the hems for added durability",
                   Price = 18.72M,
                   ImagePath = "/images/Product/blue pants.jpg",
                   Category = "Pant",
                   StockQuantity = 8,
               },
                 new Product
                 {
                     Id = 11,
                     Name = "Ray-Ban Meta Glasses, Wayfarer - Matte Black",
                     Description = "Get the most out of the moment with iconic Ray-Ban style and technology by Meta. Now featuring frames for a broader range of face shapes.\r\nOwn the moment with Ray-Ban Meta glasses. Capture your point of view, enjoy hands-free connection, listen to music and ask Meta AI* questions about the world around you.\r\nVideo call hands-free and share your POV so others can feel like they’re right there with you whether you’re cooking, watching a game or sharing core memories.",
                     Price = 409M,
                     ImagePath = "/images/Product/rayban.jpg",
                     Category = "Sunglasses",
                     StockQuantity = 2,
                 },
                    new Product
                    {
                        Id = 12,
                        Name = "KALIYADI Polarized Sunglasses for Men and Women, Mens Sunglasses Polarized UV Protection for Fishing Running Driving",
                        Description = "These KALIYADI polarized sunglasses for men adopted a classic and timeless fashion style. Retro square frame design is accented by rivets embellishment, perfect for those who seek equal parts performance and style. We created this upgraded mens sunglasses polarized with sports style and curved frame, which make wearer look cooler no matter what clothes match.",
                        Price = 123M,
                        ImagePath = "/images/Product/banana republic.jpg",
                        Category = "Sunglasses",
                        StockQuantity = 21,
                    },
                         new Product
                         {
                             Id = 13,
                             Name = "Nike Men's Giannis Immortality 3 Basketball Shoes",
                             Description = "See the grooves splitting down the middle of the outsole? They give you more flexibility to make side-to-side movements like the Euro step easier to pull off, whether you’re in transition or swiveling around a defender at the rim.\r\nWe made the midsole’s foam softer than the Giannis Immortality 2, for a more flexible underfoot experience when sprinting the floor and filling the lanes.\r\nA synthetic midfoot strap helps keep your foot steady when moving from side to side. The upper uses a light, breathable mesh to help keep your foot cool.\r\nOversized pull loop on the heel helps you slide into the shoe quick and easy.",
                             Price = 99.99M,
                             ImagePath = "/images/Product/nike.jpg",
                             Category = "Shoes",
                             StockQuantity = 1,
                         },
                            new Product
                            {
                                Id = 14,
                                Name = "Under Armour Mens Charged Assert 10 Running Shoe",
                                Description = "Lightweight, breathable mesh upper with synthetic overlays for added durability & support\r\nEVA sockliner provides soft, step-in comfort\r\nCharged Cushioning midsole uses compression molded foam for ultimate responsiveness & durability\r\nSolid rubber outsole covers high impact zones for greater durability with less weight\r\nOffset: 10mm\r\nWeight: 9.5 oz.",
                                Price = 53.35M,
                                ImagePath = "/images/Product/under armour.jpg",
                                Category = "Shoes",
                                StockQuantity = 13,
                            },
                               new Product
                               {
                                   Id = 15,
                                   Name = "BENYAR Mens Watches/Montre Homme Chronograph Analog Quartz Waterproof Wrist Watch for Men Business Casual Sport",
                                   Description = "Design Concept: BY BENYAR is dedicated to glamor of men's wrists. BY-5140 mens dress watch embraces 45MM classic big face dial, timeless chronograph design, fashion hands/markers, calendar window, tachymeter numerals on the bezel, Combining elegance, fashion and power, will become a fashion statement for your versatile style. Benyar men's wrist watches are special designed for men who looking for detail and taste!\r\nPrecision Timekeeping: BY-5140 men's watch features a high-quality original imported quartz movement to provide stable and accurate time. Whether for meaningful gatherings or formal business occasions, benyar analog quartz watch men provides you with precise timekeeping. Built-in high-quality BATTERY, the service life is as long as 2-3 years. With three chronograph sub-dials for seconds, minutes, and hours, this chronograph watches for men cater to various timing needs in your daily life.",
                                   Price = 49.98M,
                                   ImagePath = "/images/Product/benyers.jpg",
                                   Category = "Watches",
                                   StockQuantity = 13,
                               },
                               new Product
                               {
                                   Id = 16,
                                   Name = "Casio Men's Diver Style Stainless Steel Watch",
                                   Description = "50M Water Resistance\r\nDate Indicator at 3 o'clock Position\r\nStainless Steel Band\r\nTriple Fold Clasp\r\n3 Year Battery life on SR626SW Style Battery",
                                   Price = 859.98M,
                                   ImagePath = "/images/Product/casio.jpg",
                                   Category = "Watches",
                                   StockQuantity = 18,
                               }
            );
        }

    }
}
