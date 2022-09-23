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
                        EstimatebyDollar = 35924,
                        Population = 1331000
                    },

                    new GDP
                    {
                        Country = "Morocco",
                        Region = "Africa",
                        EstimatebyDollar = 3000,
                        Population = 36510000
                    },

                    new GDP
                    {
                        Country = "Austria",
                        Region = "Europe",
                        EstimatebyDollar = 48105,
                        Population = 8059000
                    },

                    new GDP
                    {
                        Country = "switzerland ",
                        Region = "Europe",
                        EstimatebyDollar = 86410,
                        Population = 8137000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}