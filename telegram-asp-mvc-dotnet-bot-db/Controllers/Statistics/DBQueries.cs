using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TelegramAspMvcDotnetBotDb.Models;
using Microsoft.EntityFrameworkCore;

namespace TelegramAspMvcDotnetBotDb.Controllers.Statistics
{
    public class DBQueries
    {
        public static string GetTop5()
        {
            string message;
            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            var result = context.Games
                .GroupBy(m => m.PlayerID)
                .Select(m => new
                {
                    Key = m.Key,
                    Total = m.Count(),
                    Win = m.Sum(c => c.IsWin),
                    Persent = m.Sum(c => c.IsWin) * 100/ m.Count()
                })
                .OrderByDescending(m => m.Persent)
                .Take(5)
                ;
            var list = result.Join(context.Players,
                p => p.Key,
                c => c.Id,
                (p, c) => new StatisticsDTO
                {
                    PlayerName = c.FirstName + " " + c.LastName,
                    Total = p.Total,
                    Win = p.Win,
                    Persent = p.Persent
                })
                .ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0,-3}{1,-25}{2,-8}{3,-8}{4,-8}\n", "#", "Игрок", "Всего", "Побед", "Проц.");
            foreach (StatisticsDTO p in list)
                sb.AppendFormat("{0,-3}{1,-25}{2,-8}{3,-8}{4,-8:F0}\n", "\U0001F6A9", p.PlayerName, p.Total, p.Win, p.Persent);

            message = sb.ToString();
            return message;
        }
    }
}
