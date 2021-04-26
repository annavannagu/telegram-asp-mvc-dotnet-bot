using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramAspMvcDotnetBotDb.Controllers.Games;

namespace TelegramAspMvcDotnetBot.Models.Commands
{
    public class AnswerCommand
    {
      
        public async Task Execute(CallbackQuery callback_query, TelegramBotClient botClient)
        {
            var chatId = callback_query.Message.Chat.Id;
            var tgId = callback_query.From.Id;
            string messageText;

            Answer answer = new(tgId);
            bool isGame = answer.IsGameExist();
            if (isGame)
            {
                bool result = answer.Check(callback_query.Data);

                if (result)
                {
                    messageText = string.Format("Угадал \U00002705! \nСыграем /play еще!");
                }
                else
                {
                    messageText = string.Format("Упс \U0000274C! \nНет! \nСыграем /play еще!");
                }
            }
            else
            {
                messageText = string.Format("ОЙ!\n \U0000274C! \nНажми /play сначала!");
            }  

            await botClient.SendTextMessageAsync(
                chatId,
                messageText,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
