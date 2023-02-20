using eTickets.Models;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //reference to the DB
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                
                //Adds Cinema
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://th.bing.com/th/id/OIP.uA4HiiRD45UqaNDnYwUqpQHaHa?pid=ImgDet&rs=1",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //Adds Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Fullname = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureUrl = "https://th.bing.com/th?id=OSK.88315fd32e6f40d3c6d27aa5964758d3&w=120&h=168&c=4&rs=1&qlt=80&o=6&pid=SANGAM"
                        }
                    });
                    context.SaveChanges();
                }
                
                //Adds Producers
                if(!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Fullname = "Producer 1",
                            Bio = "This is the Bio of the first producer",
                            ProfilePictureUrl = "https://th.bing.com/th/id/R.c2e30b25feb375f6b19bda353a4e6010?rik=C1QTljT7FGokBQ&pid=ImgRaw&r=0"
                        }
                    });
                    context.SaveChanges();
                }

                //Adds Movies
                if(!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Iron Man",
                            Description = "This is the Iron Man description",
                            Price = 39.50,
                            ImageUrl = "https://th.bing.com/th/id/R.dc6072bd82f5c534f7f7583f451a5534?rik=GqOVQyAWzMtbcw&pid=ImgRaw&r=0",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = Enums.MovieCategory.Action
                        }
                    });
                    context.SaveChanges();
                }

                //Adds Actors & Movies
                if(!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                    });
                    context.SaveChanges();
                }
            }

        }
    }
}
