using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Logic.Model;
#nullable disable

namespace DataAccess.Entities
{
    [Table("Club")]
    public partial class ClubEntity
    {
        public ClubEntity()
        {

        }
        public ClubEntity(Club item)
        {
            Name = item.Name;
            Players = (from player in item.Players select new PlayerEntity(player)).ToList();
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<PlayerEntity> Players { get; set; }
    }
}
