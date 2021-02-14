using System;

namespace Models.Activity
{
    public enum Action
    {
        Buy,
        Sell,
        CreateIsland,
        UpdateIsland,
        CreateVillager,
        UpdateVillager,
        RegisterStalk
    }

    public class Activity
    {
        public Guid Actor;
        public Action Action;
        public string[] Values;
        public DateTime Timestamp;
    }

}