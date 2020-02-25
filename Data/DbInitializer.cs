using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeloVMONT.Data
{
    public class DbInitializer
    {
        public static void Initialize(FavorisContext context)
        {
            context.Database.EnsureCreated();
                
            if (context.Favoris.Any())
            {
                return;
            }

            var favories = new Models.Favoris[]
            {
                new Models.Favoris{idFav=7},
                new Models.Favoris{idFav=6}
            };

            foreach (Models.Favoris f in favories)
            {
                context.Favoris.Add(f);
            }
            context.SaveChanges();
        }
    }
}
