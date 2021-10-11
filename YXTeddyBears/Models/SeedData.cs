using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YXTeddyBears.Data;

namespace YXTeddyBears.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YXTeddyBearsContext(
                serviceProvider.GetRequiredService<DbContextOptions<YXTeddyBearsContext>>()))
            {
                if(context.TeddyBears.Any())
                {
                    return;
                }

                context.TeddyBears.AddRange(
                    new TeddyBears
                    {
                        Name = "Stuffed Soft Panda",
                        Price = 24.99M,
                        Color = "Black and White",
                        Material = "‎Polyester",
                        Height = 29.97M,
                        Weight = 330M,
                        Manufacturer = "MINISO",
                        ImageURL = "~/img/Panda.png"
                    },

                    new TeddyBears
                    {
                        Name = "Giant Teddy Bear",
                        Price = 159.99M,
                        Color = "Pink",
                        Material = "‎‎Plush",
                        Height = 198.12M,
                        Weight = 8720M,
                        Manufacturer = "IKASA",
                        ImageURL = "~/img/Giant_Teddy.png"
                    },

                    new TeddyBears
                    {
                        Name = "White Polar Bear",
                        Price = 27.99M,
                        Color = "White",
                        Material = "‎‎Polyester",
                        Height = 20M,
                        Weight = 120M,
                        Manufacturer = "Apricot Lamb",
                        ImageURL = "~/img/Polar_Bear.png"
                    },

                    new TeddyBears
                    {
                        Name = "Stuffed Black Bear",
                        Price = 16.99M,
                        Color = "Black",
                        Material = "‎‎Plush",
                        Height = 26.19M,
                        Weight = 82M,
                        Manufacturer = "Bearington Collection",
                        ImageURL = "~/img/Black_Bear.png"
                    },

                    new TeddyBears
                    {
                        Name = "Romantic Gift Bear for Couple",
                        Price = 21.38M,
                        Color = "Brown",
                        Material = "‎‎Plush",
                        Height = 12.7M,
                        Weight = 192M,
                        Manufacturer = "SinMan",
                        ImageURL = "~/img/Romantic_Bear.png"
                    },

                    new TeddyBears
                    {
                        Name = "Teddy Bear with Big Heart and Neck Ribbon",
                        Price = 16.89M,
                        Color = "Light Brown",
                        Material = "‎‎Plush",
                        Height = 17.8M,
                        Weight = 170M,
                        Manufacturer = "La Table Blonche",
                        ImageURL = "~/img/Heart_Ribbon.png"
                    },

                    new TeddyBears
                    {
                        Name = "Baby's First Teddy Bear",
                        Price = 22.99M,
                        Color = "Pink",
                        Material = "‎‎Plush",
                        Height = 30.48M,
                        Weight = 140M,
                        Manufacturer = "Bearington Collection",
                        ImageURL = "~/img/Baby_First.png"
                    },

                    new TeddyBears
                    {
                        Name = " LED Sparkling Teddy Bear",
                        Price = 17.99M,
                        Color = "White",
                        Material = "‎‎Plush",
                        Height = 45M,
                        Weight = 130M,
                        Manufacturer = "Ewer",
                        ImageURL = "~/img/LED_Bear.png"
                    },

                    new TeddyBears
                    {
                        Name = " Doll Bear with Sleeping Soft Music",
                        Price = 49.99M,
                        Color = "Blue",
                        Material = "‎‎Plush",
                        Height = 24.21M,
                        Weight = 472M,
                        Manufacturer = "Gooidea",
                        ImageURL = "~/img/Music_Bear.jpg"
                    },

                    new TeddyBears
                    {
                        Name = " Mini Bear Keychain",
                        Price = 13.79M,
                        Color = "White",
                        Material = "‎‎Metal, plastic, flannel",
                        Height = 13M,
                        Weight = 31M,
                        Manufacturer = "PRETYZOOM",
                        ImageURL = "~/img/Keychain.png"
                    }



                    );
                context.SaveChanges();
            }
        }
    }
}
