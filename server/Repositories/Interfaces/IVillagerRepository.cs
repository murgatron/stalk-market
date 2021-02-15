using System;
using System.Collections.Generic;
using Models.CreateVillager;
using Models.Villager;

namespace Repositories.Interfaces
{
    public interface IVillagerRepository
    {
        IEnumerable<Villager> GetVillagers();
        IEnumerable<Villager> CreateVillager(CreateVillager villagersToCreate);
        IEnumerable<Villager> UpdateVillager(Guid villagerId, CreateVillager updatePayload);
        void DeleteVillager(Guid villagerId);
    };
}