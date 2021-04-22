using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramAspMvcDotnetBotDb.Models
{
    public class StatisticsDTO
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int Total { get; set; }
        public int Win { get; set; }
        public decimal Persent { get; set; }

    }
}
