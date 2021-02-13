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
        public Guid id;
        public Guid islandId;
        public Meridian meridian;
        public int bellPrice;
        public DateTime date;
        public Guid enteredBy;
    }
}