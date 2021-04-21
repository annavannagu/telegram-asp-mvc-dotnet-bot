using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramAspMvcDotnetBotDb.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public int TGId { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
