using GC_MVC_SQL_WIN_MAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_MVC_SQL_WIN_MAC.Data
{
    public class DbInit
    {

        // The code checks if there are any pants in the database, and if not, it assumes the database is new and needs to be seeded with test data.
        // It loads test data into arrays rather than List<T> collections to optimize performance.
       
        public static void Init(PantsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pants.Any())
            {
                return;
            }

            var pants = new Pants[]
            {
                new Pants {Brand="Hamtown", Color="Grey", Length=34, Price=59.99, ProductName="Bad2TheBone Pre Stained", Size=Size.L, Waist=36 },
                new Pants {Brand="Leevy", Color="Blue", Length=30, Price=39.99, ProductName="Ultra Normal", Size=Size.M, Waist=30 },
                new Pants {Brand="Jencol", Color="Dark Blue", Length=28, Price=109.99, ProductName="Extreme Baggy", Size=Size.S, Waist=28 }
            };

            foreach (Pants p in pants)
            {
                context.Pants.Add(p);
            }

            context.SaveChanges();
        }
    }
}
