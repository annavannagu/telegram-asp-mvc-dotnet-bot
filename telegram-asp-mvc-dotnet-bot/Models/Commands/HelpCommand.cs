using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramAspMvcDotnetBot.Models.Commands
{
    public class HelpCommand: Command
    {
        public override string Name => @"/help";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            string messageText = "Я умею загадывать новые флаги по команде /play\nи показывать статистику по команде /stat";
            await botClient.SendTextMessageAsync(chatId, messageText, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
