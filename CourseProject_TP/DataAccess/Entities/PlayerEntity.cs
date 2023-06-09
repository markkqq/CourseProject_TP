using Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataAccess.Entities
{
    [Table("Player")]
    public partial class PlayerEntity
    {
        public PlayerEntity()
        {

        }
        public PlayerEntity(Player player)
        {
            Name = player.Name;
            Surname = player.Surname;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }


    }
}
