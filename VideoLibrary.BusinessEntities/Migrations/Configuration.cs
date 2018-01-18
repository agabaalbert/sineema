using RandomNameGeneratorLibrary;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<VideoLibrary.BusinessEntities.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VideoLibrary.BusinessEntities.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Actors.AddOrUpdate(
            //  p => p.Name,
            //  new Actor { Name = "Andrew Peters" },
            //  new Actor { Name = "Brice Lambson" },
            //  new Actor { Name = "Rowan Miller" }
            //);

            SeedData(10);//Seed actors and momies
        }

        private void SeedData(long count)
        {
            using (var db = new LibraryContext())
            {

                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int itemcount = 0;
                        bool isMale = true;
                        DateTime start = new DateTime(1900, 1, 1);
                        var randDate = new Random();
                        do
                        {
                            itemcount++;
                            isMale = !isMale;
                            var actor = new Actor
                            {
                                Name = GetName(isMale),
                                DateOfBirth = start.AddDays(randDate.Next(100)),
                                Gender = isMale ? Gender.Male : Gender.Female,
                                Genre = "M",
                                NumberOfMovies = itemcount
                            };

                            actor = db.Actors.Add(actor);
                            db.SaveChanges();
                            
                            var noOfmoviews = 0;

                            Array values = Enum.GetValues(typeof(Genre));
                            Random random = new Random();
                            do
                            {
                                noOfmoviews++;

                                var movie = new Movie
                                {
                                    Title = Faker.Company.Name(),
                                    Duration = noOfmoviews,
                                    Genre = (Genre)values.GetValue(random.Next(values.Length)),
                                    LeadActorId = actor.Id,
                                    Actor = actor
                                };

                                //context.Movies.AddOrUpdate(p => p.Title, movie);

                                db.Movies.Add(movie);

                            } while (noOfmoviews <= actor.NumberOfMovies);
                            db.SaveChanges();
                        } while (itemcount <= count);

                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }


        private string GetName(bool male)
        {
            var generator = new PersonNameGenerator();
            return male ? generator.GenerateRandomMaleFirstAndLastName() : generator.GenerateRandomFemaleFirstAndLastName();

        }
    }
}
