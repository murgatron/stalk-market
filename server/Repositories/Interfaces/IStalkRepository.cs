using System;
using System.Collections.Generic;
using Models.CreateStalk;
using Models.Stalk;

namespace Repositories.Interfaces
{
    // No Updates. Only Create/Delete. 
    public interface IStalkRepository
    {
        IEnumerable<Stalk> GetStalks();
        IEnumerable<Stalk> CreateStalk(CreateStalk createStalk);
        void DeleteStalk(Guid stalkId);
    }
}