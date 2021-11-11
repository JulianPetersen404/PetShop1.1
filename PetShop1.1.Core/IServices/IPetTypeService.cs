using System.Collections.Generic;
using PetShop1._1.Core.Models;

namespace PetShop1._1.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetPetTypes();
        PetType GetPetType(int id);
    }
}