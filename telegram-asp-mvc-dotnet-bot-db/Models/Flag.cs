using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramAspMvcDotnetBotDb.Models
{
    public class Flag
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }

        [MaxLength(128),Required]
        public string ImageName { get; set; }
        [MaxLength(128),Required]
        public string Country { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
