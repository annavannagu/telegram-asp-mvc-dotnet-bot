using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace TelegramAspMvcDotnetBotDb.Controllers.Players
{
    public class ExistentUser
    {        
        public static bool Check(int tgId)
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            var user = context.Players
                .Where(m => m.TGId == tgId)
                .FirstOrDefault();
            return true;
        }
    }
}
