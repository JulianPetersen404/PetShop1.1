using System.Collections.Generic;
using PetShop1._1.Core.Models;
using PetShop1._1.Domain.IRepositories;

namespace Data
{
    public class PetTypeRepository : IPetTypeRepository
    {
        
        public List<PetType> getPetTypes()
        {
            List<PetType> petTypes = new List<PetType>();

            PetType type1 = new PetType
            {
                ID = 1,
                Name = "Dog"
            };petTypes.Add(type1);
            PetType type2 = new PetType
            {
                ID = 2,
                Name = "cat"
            };petTypes.Add(type2);
            PetType type3 = new PetType
            {
                ID = 3,
                Name = "Horse"
            };petTypes.Add(type3);

            return petTypes;
        }
        public PetType getPetType(int id)
        {
            List<PetType> petTypes = new List<PetType>();
            foreach (var pT in petTypes)
            {
                if (pT.ID.Equals(id))
                    return pT;
            }

            return null;
        }
    }
}