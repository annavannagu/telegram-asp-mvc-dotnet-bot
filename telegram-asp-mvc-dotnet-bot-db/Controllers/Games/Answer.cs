using System;
using System.Collections.Generic;
using System.Text;
using TelegramAspMvcDotnetBotDb.Models;
using System.Linq;

namespace TelegramAspMvcDotnetBotDb.Controllers.Games
{
    public class Answer
    {
        private Player Player { get; set; }
        private Flag GivenFlag { get; set; }

        public Answer(int tgId)
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            Player = context.Players
                .Where(m => m.TGId == tgId)
                .FirstOrDefault();
        }

        public bool Check(string answer)
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();


            int flagID = context.Games
                .Where(m => m.PlayerID == Player.Id && m.IsAnswered == false)
                .Select(m => m.FlagID)
                .FirstOrDefault();

            if (flagID > 0)
            {
                GivenFlag = context.Flags
                .Where(m => m.Id == flagID)
                .FirstOrDefault();

                bool result = false;
                if (answer == GivenFlag.Country)
                {
                    result = true;
                }

                UpdateDB(result);

                return result;
            }
            else
            {
                return false;
            }                        
        }

        public bool IsGameExist()
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();


            int flagID = context.Games
                .Where(m => m.PlayerID == Player.Id && m.IsAnswered == false)
                .Select(m => m.FlagID)
                .FirstOrDefault();

            if (flagID > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void UpdateDB(bool result)
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            Game game = context.Games
                .Where(m => m.PlayerID == Player.Id && m.IsAnswered == false)
                .FirstOrDefault();

            switch (result)
            {
                case true:
                    game.IsWin = 1;
                    break;
                case false:
                    game.IsWin = 0;
                    break;
            }
            game.IsAnswered = true;
            context.SaveChanges();
        }
    }
}
