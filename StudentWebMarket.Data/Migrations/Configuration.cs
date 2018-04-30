namespace StudentWebMarket.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StudentWebMarket.Data.EF;
    using StudentWebMarket.Models.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentWebMarketDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentWebMarketDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedUserWithProducts(context);
        }

        private void SeedUserWithProducts(StudentWebMarketDbContext context)
        {
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test_user@gmail.com",
                UserName = "testUser",
                PhoneNumber = "12 345 678",
                //UserPhoto = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                //    "@../StudentMarket.Data/Migrations/Images/profileimage.jpg")),
                RegistrationDate = new DateTime(2015, 1, 10)
            };

            var createdUser = context.Users
                .Where(u => string.Compare(u.Email, user.Email, true) == 0)
                .FirstOrDefault();
            if (createdUser == null)
            {
                this.userManager.Create(user, "123456");

                var product1 = new Product
                {
                    OriginalPrice = 2000,
                    SalePrice = 800,
                    CreatedOn = new DateTime(2017, 1, 10),
                    Year = 2017,
                    Description = "Android 4.4 Kit Kat OS, 1.2 GHz quad-core processor",
                    Name = "Samsung Galaxy"

                };
                product1.Seller = user;

                var image = new Image
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../StudentWebMarket.Data/Migrations/Images/samsung-galaxy.jpg")),
                    FileExtension = "jpg"
                };
                product1.Image = image;

                var category = new Category
                {
                    Name = "Tablets",
                };
                product1.Category = category;

                var condition = new Condition
                {
                    Name = "Used - Like New"
                };
                product1.Condition = condition;

                var product2 = new Product
                {
                    OriginalPrice = 1200,
                    SalePrice = 600,
                    CreatedOn = new DateTime(2017, 2, 8),
                    Year = 2016,
                    Description = "Pad 7 ME170CX-A1-BK 7-Inch 16GB Tablet. Dual-Core Intel Atom Z2520 1.2GHz CPU",
                    Name = "ASUS MeMO"

                };
                product2.Seller = user;

                var image2 = new Image
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../StudentWebMarket.Data/Migrations/Images/asus-memo.jpg")),
                    FileExtension = "jpg"
                };
                product2.Category = category;
                product2.Condition = condition;
                product2.Image = image2;

                var product3 = new Product
                {
                    OriginalPrice = 3500,
                    SalePrice = 1500,
                    CreatedOn = new DateTime(2018, 2, 3),
                    Year = 2018,
                    Description = "This Certified Refurbished product is manufacturer refurbished, shows limited or no wear, and includes all original accessories plus a 90-day warranty",
                    Name = "HP Pavilion 15-r030wm"

                };
                product3.Seller = user;

                var image3 = new Image
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../StudentWebMarket.Data/Migrations/Images/hp-pavilion.jpg")),
                    FileExtension = "jpg"
                };
                product3.Image = image3;

                var category2 = new Category
                {
                    Name = "Laptops",
                };
                product3.Category = category2;

                var condition2 = new Condition
                {
                    Name = "Used - Very Good"
                };

                var product4 = new Product
                {
                    OriginalPrice = 4000,
                    SalePrice = 2000,
                    CreatedOn = new DateTime(2018, 2, 8),
                    Year = 2017,
                    Description = "Intel Celeron N2830 Processor, 15.6-Inch Screen, Intel HD Graphics",
                    Name = "Dell Inspiron 15.6-Inch",

                };
                product4.Seller = user;

                var image4 = new Image
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../StudentWebMarket.Data/Migrations/Images/dell-inspiron.jpg")),
                    FileExtension = "jpg"
                };
                product4.Image = image4;
                product4.Category = category2;
                product4.Condition = condition2;
                var product5 = new Product
                {
                    OriginalPrice = 3000,
                    SalePrice = 1000,
                    CreatedOn = new DateTime(2017, 1, 10),
                    Year = 2017,
                    Description = "13 MP Rear Facing BSI Camera / 5 MP Front Facing",
                    Name = "HTC Desire 816"

                };
                product5.Seller = user;

                var image5 = new Image
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../StudentWebMarket.Data/Migrations/Images/htc-desire.jpg")),
                    FileExtension = "jpg"
                };
                product5.Image = image5;

                var category3 = new Category
                {
                    Name = "Mobiles",
                };
                product5.Category = category3;

                var condition3 = new Condition
                {
                    Name = "Used - Acceptable"
                };
                product5.Condition = condition3;

                var product6 = new Product
                {
                    OriginalPrice = 2500,
                    SalePrice = 1300,
                    CreatedOn = new DateTime(2018, 2, 8),
                    Year = 2017,
                    Description = "T-Mobile Cell Phone 4G - White. 5MP Camera - Snap creative photos with built-in digital lenses",
                    Name = "Nokia Lumia 521",

                };
                product6.Seller = user;

                var image6 = new Image
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../StudentWebMarket.Data/Migrations/Images/nokia-lumia.jpg")),
                    FileExtension = "jpg"
                };



                var product7 = new Product
                {
                    OriginalPrice = 1500,
                    SalePrice = 800,
                    CreatedOn = new DateTime(2015, 3, 1),
                    Year = 2017,
                    Description = "Head First Java delivers a highly interactive, multisensory learning experience that lets new programmers pick up the fundamentals of the Java language quickly",
                    Name = "Head First Java",

                };
                product7.Seller = user;
                var category4 = new Category
                {
                    Name = "Books",
                };
                product7.Category = category4;

                var image7 = new Image
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../StudentWebMarket.Data/Migrations/Images/java.jpg")),
                    FileExtension = "jpg"
                };
                product7.Image = image7;
                product7.Condition = condition2;

                var product8 = new Product
                {
                    OriginalPrice = 500,
                    SalePrice = 300,
                    CreatedOn = new DateTime(2018, 4, 8),
                    Year = 2017,
                    Description = "A full-color introduction to the basics of HTML and CSS",
                    Name = "Pro HTML and CSS3",

                };
                product8.Seller = user;

                var image8 = new Image
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../StudentWebMarket.Data/Migrations/Images/aspnet.jpg")),
                    FileExtension = "jpg"
                };
                product8.Image = image8;
                product8.Condition = condition;
                product8.Category = category4;
                product6.Image = image6;
                product6.Category = category3;
                product6.Condition = condition3;
                product3.Condition = condition2;

                context.Products.Add(product1);
                context.Products.Add(product2);
                context.Products.Add(product3);
                context.Products.Add(product4);
                context.Products.Add(product5);
                context.Products.Add(product6);
                context.Products.Add(product7);
                context.Products.Add(product8);
                context.SaveChanges();

            }

        }
    }
}

