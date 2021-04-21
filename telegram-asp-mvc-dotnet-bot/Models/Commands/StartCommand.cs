using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramAspMvcDotnetBot.Models.Commands
{
    public class StartCommand: Command
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            var clientName = message.From.FirstName;
            string messageText = string.Format("Привет {0}!\nЖми /play для новой игры!", clientName);
            await botClient.SendTextMessageAsync(chatId, messageText, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
