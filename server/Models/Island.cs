using System;

namespace models.Island
{
    public class Island
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Owner { get; set; }
    }
}