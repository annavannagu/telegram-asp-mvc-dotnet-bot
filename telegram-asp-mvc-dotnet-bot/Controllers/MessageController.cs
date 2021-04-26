using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramAspMvcDotnetBot.Models;
using TelegramAspMvcDotnetBot.Models.Commands;

namespace TelegramAspMvcDotnetBot.Controllers
{
    [Route("api/message/update")]
    public class MessageController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Method GET unavailable!";
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody] Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;

            var botClient = await Bot.GetBotClientAsync();

            var message = update.Message;

            if (message != null)
            {
                foreach (var command in commands)
                {
                    if (command.Contains(message))
                    {
                        await command.Execute(message, botClient);
                        break;
                    }
                }
            };

            var callback_query = update.CallbackQuery;

            if (callback_query != null)
            {
                AnswerCommand cmd = new();
                await cmd.Execute(callback_query, botClient);
            }

            return Ok();
        }

    }
}
