using System;
using Enums;

namespace Models.Activity
{
    public class Activity
    {
        public Guid Actor;
        public StalkMarketAction Action;
        public string[] Values;
        public DateTime Timestamp;
    }

}