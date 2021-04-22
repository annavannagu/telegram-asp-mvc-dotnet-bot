using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramAspMvcDotnetBotDb.Controllers.Statistics;

namespace TelegramAspMvcDotnetBot.Models.Commands
{
    public class StatCommand: Command
    {
        public override string Name => @"/stat";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            string messageText = DBQueries.GetTop5();
            await botClient.SendTextMessageAsync(chatId, messageText, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
