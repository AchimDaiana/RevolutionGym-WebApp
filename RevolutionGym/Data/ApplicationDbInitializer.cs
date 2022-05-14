using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data
{
    public class ApplicationDbInitializer
    {
        public static void SeedDb(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                //Trainers
                if (!context.Trainers.Any()) //daca nu sunt date adauga prin ce e mai jos
                {
                    context.Trainers.AddRange(new List<Trainer>()
                    {
                        new Trainer()
                        {
                            FirstName ="Pamela",
                            LastName="Reif",
                            ProfilePicture="https://bilder.bild.de/fotos-skaliert/pamela-reif-200234393-49599952/3,c=0,h=1026.bild.jpg",
                            Biography="Pamela Reif și-a început călătoria în fitness pe rețelele de socializare încă din 2012, când avea doar 16 ani. " +
                        "Exercițiile ei preferate sunt podurile pentru fesieri, genuflexiunile, miscarile abdominale sau orice fel de seturi de greutate corporală."
                        },
                    });
                    context.SaveChanges();
                }
                //Subscription
                if (!context.Subscriptions.Any()) //daca nu sunt date adauga prin ce e mai jos
                {
                    context.Subscriptions.AddRange(new List<Subscription>()
                    {
                        new Subscription()
                        {
                            Name="Abonament Kangoo Jumps",
                            Validity="o luna",
                            Price= 120,
                            Picture="https://www.kangoo-jumps.org/media/catalog/product/cache/1/image/600x600/9df78eab33525d08d6e5fb8d27136e95/c/h/cheap_kangoo_jumps_shoes_fitness_outdoor_bounce_sports_jump_shoes_new_style_black-blue_kangoo_jumps_1_.jpg",
                            Description="Pentru toate varstele"
                        },
                    });
                    context.SaveChanges();
                }
                //Training
                if (!context.Trainings.Any()) //daca nu sunt date adauga prin ce e mai jos
                {
                    context.Trainings.AddRange(new List<Training>()
                    {
                        new Training()
                        {
                           Name="Kangoo",
                           Description="Pentru toate varstele",
                           Picture="https://bestofyou.gr/sites/default/files/styles/compressed_effects/public/2021-06/KANGOO%20JUMPS.jpg?itok=IUbCqh2S",
                           StartHour=DateTime.Now,
                           FinishHour=DateTime.Now,
                           Category = Enums.TrainingCategory.LowerBody,
                           TrainerId = 1,
                           SubscriptionId = 1

                        },
                    });
                    context.SaveChanges();
                }


            }
        }
    }
}
