using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramAspMvcDotnetBotDb.Controllers.Players
{
    public interface ILogUserService
    {
        /// <summary>
        /// Telegram UserID
        /// </summary>
        int TGId { get; set; }
        /// <summary>
        /// Telegram User First Name
        /// </summary>
        string FirstName { get; set; }
        /// <summary>
        /// Telegram User Last Name
        /// </summary>
        string LastName { get; set; }
        /// <summary>
        /// Telegram UserName
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// Method responsible for creating/loggining user
        /// </summary>
        /// <returns></returns>
        bool ProcessLoggining();
    }
}
