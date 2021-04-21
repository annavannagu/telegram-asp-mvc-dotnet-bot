using System;
using System.Collections.Generic;
using System.Text;
using TelegramAspMvcDotnetBotDb.Controllers.Players;
using TelegramAspMvcDotnetBotDb.Models;

namespace TelegramAspMvcDotnetBotDb.Controllers.Players
{
    class NewUserLogging: ILogUserService
    {
        public int TGId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool ProcessLoggining() 
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            var player = new Player
            {
                TGId = TGId,
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName
            };

            context.Players.Add(player);
            context.SaveChanges();
            return true;
        }
    }
}
