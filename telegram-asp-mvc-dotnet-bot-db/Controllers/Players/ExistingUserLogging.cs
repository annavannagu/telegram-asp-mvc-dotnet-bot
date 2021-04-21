using System;
using System.Collections.Generic;
using System.Text;
using TelegramAspMvcDotnetBotDb.Controllers.Players;
using TelegramAspMvcDotnetBotDb.Models;

namespace TelegramAspMvcDotnetBotDb.Controllers.Players
{
    class ExistingUserLogging : ILogUserService
    {
        public int TGId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool ProcessLoggining()
        {
            return true;
        }
    }
}
