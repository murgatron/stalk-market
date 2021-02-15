using System;

namespace Models.Villager
{
    public class Villager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }

    }
}