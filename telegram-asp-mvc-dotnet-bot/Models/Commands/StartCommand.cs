﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramAspMvcDotnetBotDb.Controllers.Players;

namespace TelegramAspMvcDotnetBot.Models.Commands
{
    public class StartCommand : Command
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
            var tgId = message.From.Id;
            var firstname = message.From.FirstName;
            var lastname = message.From.LastName;
            var username = message.From.Username;

            bool isExist = ExistentUser.Check(tgId);

            if (!isExist)
            {
                LoginUser(LoggingServiceFactory.ServicesAvailable.New, tgId, firstname, lastname, username);
            }   
                        
            string messageText = string.Format("Привет {0}!\nЖми /play для новой игры!", firstname);
            await botClient.SendTextMessageAsync(chatId, messageText, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }

        static void LoginUser(LoggingServiceFactory.ServicesAvailable servicesAvailable, int tgId, string firstname, string lastname, string username)
        {
            LoggingServiceFactory factory = new();
            var service = factory.Create(servicesAvailable);
            service.TGId = tgId;
            service.FirstName = firstname;
            service.LastName = lastname;
            service.UserName = username;
            service.ProcessLoggining();
        }
    }
}

