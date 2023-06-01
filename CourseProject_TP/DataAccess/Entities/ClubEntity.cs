using System.Collections.Generic;

namespace CourseProject_TP.DataAccess.Entities
{
    public class ClubEntity
    {
        public List<PlayerEntity> Players { get; set; } = new();
        public string Name { get; set; }
        public int ID { get; set; }
    }
}