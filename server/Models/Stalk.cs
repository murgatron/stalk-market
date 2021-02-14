using System;

namespace models.Stalk
{
    public enum Meridian
    {
        AM,
        PM
    }

    public class Stalk
    {
        public Guid Id { get; set; }
        public Guid IslandId { get; set; }
        public Meridian Meridian { get; set; }
        public int BellPrice { get; set; }
        public DateTime Date { get; set; }
        public Guid EnteredBy { get; set; }
    }
}