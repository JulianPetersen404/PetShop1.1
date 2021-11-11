using System;
using System.Collections.Generic;
using PetShop1._1.Core.Models;

namespace PetShop1._1.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetPets();
        List<Pet> ReadPets();

        void DeletePet(int id);
        void CreatePet(Pet pet);

        void UpdateName(int id, string name);
        void UpdateColor(int id, string color);
        void UpdatePrice(int id, double price);
        void UpdateType(int id, PetType type);
        void UpdateBirthday(int id, DateTime birthday);
        void UpdateSoldDate(int id, DateTime SoldDate);
    }
}
