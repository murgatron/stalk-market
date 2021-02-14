using System.Collections.Generic;
using Models.Villager;

namespace Interfaces.IVillagerRepository
{
    public interface IVillagerRepository
    {
        IEnumerable<Villager> GetVillagers();
    };
}