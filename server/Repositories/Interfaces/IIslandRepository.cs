using System;
using System.Collections.Generic;
using Models.CreateIsland;
using Models.Island;

namespace Repositories.Interfaces
{
    public interface IIslandRepository
    {
        IEnumerable<Island> GetIslands();
        IEnumerable<Island> CreateIsland(CreateIsland createIsland);
        IEnumerable<Island> UpdateIsland(Guid islandId, CreateIsland createIsland);
        void DeleteIsland(Guid islandId);
    }
}