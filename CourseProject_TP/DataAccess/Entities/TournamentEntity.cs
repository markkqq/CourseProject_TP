using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Logic.Model;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace DataAccess.Entities
{
    [Table("Tournament")]
    public partial class TournamentEntity
    {
        public TournamentEntity()
        {

        }
        public TournamentEntity(Tournament item)
        {
            Name = item.Name;
            GameSessions = (from gamesession in item.GameSessions select new GameSessionEntity(gamesession)).ToList();

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<GameSessionEntity> GameSessions { get; set; }
        
    }
}
