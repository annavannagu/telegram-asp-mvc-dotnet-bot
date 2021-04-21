using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramAspMvcDotnetBotDb.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public int PlayerID { get; set; }
        public Flag Flag { get; set; }
        public int FlagID { get; set; }
        public bool? IsWin { get; set; }
    }
}
