using System;
using System.Collections.Generic;
using System.Text;
using TelegramAspMvcDotnetBotDb.Controllers.Players;

namespace TelegramAspMvcDotnetBotDb.Controllers.Players
{
    public class LoggingServiceFactory
    {
        public enum ServicesAvailable
        {
            New,
            Exist
        }


        public ILogUserService Create(ServicesAvailable operation)
        {
            ILogUserService result;
            if (operation == ServicesAvailable.New)
                result = new NewUserLogging();
            else
                result = new ExistingUserLogging();
            return result;
        }
    }
}
