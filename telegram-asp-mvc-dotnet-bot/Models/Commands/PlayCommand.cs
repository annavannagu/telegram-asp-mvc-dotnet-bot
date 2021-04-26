using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramAspMvcDotnetBotDb.Controllers.Games;

namespace TelegramAspMvcDotnetBot.Models.Commands
{
    public class PlayCommand : Command
    {
        public override string Name => @"/play";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            var tgId = message.From.Id;

            string url;
            string[] answers;

            Question question = new(tgId);
            (url, answers) = question.Give();

            if (url != null)
            {
                var replyKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(answers[0], answers[0]),
                        InlineKeyboardButton.WithCallbackData(answers[1], answers[1]),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData(answers[2], answers[2]),
                        InlineKeyboardButton.WithCallbackData(answers[3], answers[3]),
                    }
                });

                url = AppSettings.ImageFolder + url;

                string messageText = string.Format("\nЧей флаг \U0001F63A?");

                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: messageText,
                    replyMarkup: new ReplyKeyboardRemove()
                    );

                using Stream stream = System.IO.File.OpenRead(url);
                await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: stream,
                    replyMarkup: replyKeyboardMarkup
                    );
            }
            else
            {
                string messageText = string.Format("Ты разгадал все флаги \U0001F61C !!!");
                
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: messageText,
                    replyMarkup: new ReplyKeyboardRemove()
                    );
            }

            

        }
    }
}

