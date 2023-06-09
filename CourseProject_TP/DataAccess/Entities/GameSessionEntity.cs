using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Logic.Model;
#nullable disable

namespace DataAccess.Entities
{
    [Table("GameSession")]
    public partial class GameSessionEntity
    {
        public GameSessionEntity()
        {

        }
        public GameSessionEntity(GameSession gameSession)
        {
            FirstClubResult = gameSession.FirstClubResult;
            SecondClubResult = gameSession.SecondClubResult;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int FirstClubResult { get; set; }
        [Required]
        public int SecondClubResult { get; set; }

        public ICollection<ClubEntity> Clubs { get; set; }
    }
}
