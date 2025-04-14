﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formationn_Ecommerce.Core.Entities.Coupon;
using Formationn_Ecommerce.Core.Entities.CategoryE;
using Microsoft.EntityFrameworkCore;

namespace Formationn_Ecommerce.Infrastucture.Persistence.DbInitializer
{
    public static class DbInitializer
    {
        public static async Task InitializeDatabase(ApplicationDbContext db)
        {
            // Seed Categories
            await SeedCategories(db);

            // Seed Coupons
            await SeedCoupons(db);
        }

        private static async Task SeedCategories(ApplicationDbContext db)
        {
            // Check if there are any categories already
            if (!await db.Categories.AnyAsync())
            {
                // Add sample categories
                await db.Categories.AddRangeAsync(
                    new Category
                    {
                        Name = "PCs & Laptops",
                        Description = "Desktop computers, laptops, and mini-PCs"
                    },
                    new Category
                    {
                        Name = "PC Components",
                        Description = "Processors, motherboards, graphics cards, RAM, and cases"
                    },
                    new Category
                    {
                        Name = "Peripherals",
                        Description = "Keyboards, mice, headphones, webcams, and microphones"
                    },
                    new Category
                    {
                        Name = "Monitors & Displays",
                        Description = "Gaming monitors, professional displays, and display accessories"
                    },
                    new Category
                    {
                        Name = "Storage",
                        Description = "Hard drives, SSDs, NAS, and external storage devices"
                    },
                    new Category
                    {
                        Name = "Network & Connectivity",
                        Description = "Routers, switches, network adapters, and WiFi equipment"
                    },
                    new Category
                    {
                        Name = "Accessories",
                        Description = "Mouse pads, laptop stands, cooling fans, and other accessories"
                    }
                );

                // Save the changes to the database
                await db.SaveChangesAsync();
            }
        }

        private static async Task SeedCoupons(ApplicationDbContext db)
        {
            // Check if there are any coupons already
            if (!await db.Coupons.AnyAsync())
            {
                // Add sample coupons
                await db.Coupons.AddRangeAsync(
                    new Coupon
                    {
                        CouponCode = "10OFF",
                        DiscountAmount = 10.00m,
                        MinimumAmount = 20.00m
                    },
                    new Coupon
                    {
                        CouponCode = "20OFF",
                        DiscountAmount = 20.00m,
                        MinimumAmount = 40.00m
                    },
                    new Coupon
                    {
                        CouponCode = "FREESHIP",
                        DiscountAmount = 5.00m,
                        MinimumAmount = 0.00m
                    },
                    new Coupon
                    {
                        CouponCode = "WELCOME",
                        DiscountAmount = 15.00m,
                        MinimumAmount = 30.00m
                    },
                    new Coupon
                    {
                        CouponCode = "HOLIDAY25",
                        DiscountAmount = 25.00m,
                        MinimumAmount = 50.00m,
                        StripeId = "holiday_25_stripe"
                    }
                );

                // Save the changes to the database
                await db.SaveChangesAsync();
            }
        }
    }
}
