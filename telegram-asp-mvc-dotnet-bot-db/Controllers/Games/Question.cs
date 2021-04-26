using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelegramAspMvcDotnetBotDb.Models;

namespace TelegramAspMvcDotnetBotDb.Controllers.Games
{
    public class Question
    {
        private Game CurrentGame { get; set; }
        private Player Player { get; set; }

        private Flag GivenFlag { get; set; }

        public Question(int tgId) 
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            Player = context.Players
                .Where(m => m.TGId == tgId)
                .FirstOrDefault();
        }

        public (string url, string[] answers) Give()
        {
            SetAllGamesPlayed();

            string url = GetImageURL();
            if (url != null)
            {
                string[] answer = GetVariants();
                SaveToDB();
                return (url, answer);
            }
            else
            {
                return (null, null);
            }
            
        }
        
        
        public string GetImageURL()
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            int[] unplayed = GetUnplayedFlagsIds();


            if (unplayed.Length > 0)
            {
                Random rnd = new Random();
                int r = rnd.Next(unplayed.Length);
                int image_number = unplayed[r];

                GivenFlag = context.Flags
                    .Where(m => m.Id == image_number)
                    .Select(m => new Flag
                    {
                        Id = m.Id,
                        Number = m.Number,
                        ImageName = m.ImageName,
                        Country = m.Country,

                    })
                    .FirstOrDefault();

                return GivenFlag.ImageName;
            }
            else
            {
                return null;
            }       
        }

        private int[] GetUnplayedFlagsIds()
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            List<int> userfalgs = context.Games
                .Where(m => m.PlayerID == Player.Id)
                .Select(m =>
                    m.FlagID
                )
                .ToList()
                ;

            List<int> allflags = context.Flags
                .Select(m =>
                    m.Id
                )
                .ToList()
                ;

            int[] uplayed = allflags.Except(userfalgs).ToArray();

            return uplayed;
        }

        private string[] GetVariants()
        {
            string[] variants = new string[4];
            string[] result = new string[4];

            int[] nums = new int[4];

            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            nums[0] = GivenFlag.Number;

            Random rnd = new Random();
            

            for (int i = 1; i < 4; i++)
            {
                int value = rnd.Next(1, 195);
                while (Array.Exists(nums, element => element == value))
                    value = rnd.Next(1, 195);
                nums[i] = value;
            }           

            for (int i = 0; i < 4; i++)
            {
                variants[i] = context.Flags
                                    .Where(m => m.Number == nums[i])
                                    .Select(m => m.Country)
                                    .FirstOrDefault();
            }

            result = variants.OrderBy(x => rnd.Next()).ToArray();

            return result;
        }


        private void SaveToDB()
        {
            CurrentGame = new Game
            {
                PlayerID = Player.Id,
                FlagID = GivenFlag.Id,
                IsAnswered = false
            };
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            context.Games.Add(CurrentGame);
            context.SaveChanges();
        } 
        
        private void SetAllGamesPlayed()
        {
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            //set all games played
            var unplayedGames = context.Games.Where(m => m.PlayerID == Player.Id && m.IsAnswered == false);

            if (unplayedGames.Any())
            {
                foreach (Game game in unplayedGames)
                {
                    game.IsAnswered = true;
                }
                context.SaveChanges();
            };
        }        
    }
}
