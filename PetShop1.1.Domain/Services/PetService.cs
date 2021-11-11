using System;
using System.Collections.Generic;
using PetShop1._1.Core.IServices;
using PetShop1._1.Core.Models;
using PetShop1._1.Domain.IRepositories;

namespace PetShop1._1.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repositorie;


        public PetService(IPetRepository repository)
        {
            _repositorie = repository;
        }
        
        public List<Pet> GetPets()
        {
            return _repositorie.GetPets();
        }

        public List<Pet> ReadPets()
        {
            return _repositorie.ReadPets();
        }

        public void DeletePet(int id)
        {
            _repositorie.DeletePet(id);
        }

        public void CreatePet(Pet pet)
        {
            _repositorie.createPet(pet);
        }

        public void UpdateName(int id, string name)
        {
            _repositorie.UpdateName(id, name);
        }

        public void UpdateColor(int id, string color)
        {
            _repositorie.UpdateColor(id, color);
        }

        public void UpdatePrice(int id, double price)
        {
            _repositorie.UpdatePrice(id, price);
        }

        public void UpdateType(int id, PetType type)
        {
            _repositorie.UpdateType(id, type);
        }

        public void UpdateBirthday(int id, DateTime birthday)
        {
            _repositorie.UpdateBirthday(id, birthday);
        }

        public void UpdateSoldDate(int id, DateTime SoldDate)
        {
            _repositorie.UpdateSoldDate(id, SoldDate);
        }
    }
}