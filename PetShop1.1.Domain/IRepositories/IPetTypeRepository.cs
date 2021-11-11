using System.Collections.Generic;
using PetShop1._1.Core.Models;

namespace PetShop1._1.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        public abstract List<PetType> getPetTypes();
        public abstract PetType getPetType(int id);
    }
}