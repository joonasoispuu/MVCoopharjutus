using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCoopkrodus.Data;
using System;
using System.Linq;

namespace MVCoopkrodus.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCoopkrodusContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVCoopkrodusContext>>()))
            {
                // Look for any movies.
                if (context.GDP.Any())
                {
                    return;   // DB has been seeded
                }

                context.GDP.AddRange(
                    new GDP
                    {
                        Country = "Estonia",
                        Region = "Europe",
                        EstimatebyDollar = 27971,
                        Population = 1331000,
                        Year = "2022"
                    },

                    new GDP
                    {
                        Country = "Morocco",
                        Region = "Africa",
                        EstimatebyDollar = 3497,
                        Population = 36510000,
                        Year = "2021"
                    },

                    new GDP
                    {
                        Country = "Austria",
                        Region = "Europe",
                        EstimatebyDollar = 53268,
                        Population = 8059000,
                        Year = "2021"
                    },

                    new GDP
                    {
                        Country = "Switzerland ",
                        Region = "Europe",
                        EstimatebyDollar = 86410,
                        Population = 86850,
                        Year = "2020"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}