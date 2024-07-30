using CodeFirstQuest.Data;
using LinqQuest.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LinqQuestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();

                context.Add(new Specie {Name = "Cougar blanc"});
                context.Add(new Specie {Name = "Tigre blanc" });
                context.Add(new Specie {Name = "Tortue albinos" });

                context.SaveChanges();

                for (int i = 0; i < 3; i++)
                {
                    context.Add(new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = i.ToString(),
                        SpecieId = 1
                    });
                }

                for (int i = 0; i < 100; i++)
                {
                    context.Add(new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = i.ToString(),
                        SpecieId = 2
                    });
                }

                for (int i = 0; i < 15; i++)
                {
                    context.Add(new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = i.ToString(),
                        SpecieId = 3
                    });
                }

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext())
            {
                List<Animal> cougarsBlancs = context.Animals.Where(el => el.SpecieId == 1).ToList();
                List<Animal> tigresBlancs = context.Animals.Where(el => el.SpecieId == 2).ToList();
                List<Animal> tortuesAlbinos = context.Animals.Where(el => el.SpecieId == 3).ToList();
                Console.Write("Nombre de cougars blancs :");
                Console.WriteLine(cougarsBlancs.Count);
                Console.Write("Nombre de tigres blancs :");
                Console.WriteLine(tigresBlancs.Count);
                Console.Write("Nombre de tortues albinos :");
                Console.WriteLine(tortuesAlbinos.Count);
            }
        }
    }
}
