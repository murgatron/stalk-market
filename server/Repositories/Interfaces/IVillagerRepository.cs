using System.Collections.Generic;
using Models.Villager;
using Models.CreateVillager;
using System;

namespace Interfaces.IVillagerRepository
{
    public interface IVillagerRepository
    {
        IEnumerable<Villager> GetVillagers();
        IEnumerable<Villager> CreateVillager(CreateVillager villagersToCreate);
        IEnumerable<Villager> UpdateVillager(Guid villagerId, CreateVillager updatePayload);
        void DeleteVillager(Guid villagerId);
    };
}