using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDirectum.Entities;

namespace TestTaskDirectum
{
    public static class InitDb
    {
        public static async Task Init(this MettingsContext db)
        {
            db.Users.AddRange(new User { Id=1, Name="Александр"}, new User { Id=2, Name = "Виктор"});
            await db.SaveChangesAsync();
        }
    }
}
