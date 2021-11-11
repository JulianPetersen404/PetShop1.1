using System;
using System.Collections.Generic;
using System.Linq;
using PetShop1._1.Core.Models;
using PetShop1._1.Domain.IRepositories;
using PetShop1._1.Domain.Services;

namespace Data
{
    public class PetRepository : IPetRepository
    {
        List<Pet> allPets = new List<Pet>();

        public List<Pet> GetPets()
        {


            PetType type1 = new PetType
            {
                ID = 1,
                Name = "Dog"
            };
            PetType type2 = new PetType
            {
                ID = 2,
                Name = "Cat"
            };
            PetType type3 = new PetType
            {
                ID = 3,
                Name = "Horse"
            };
            
            Pet pet1 = new Pet
            {

                ID = 1,
                Name = "Aaron",
                Type = type1,
                Birthday = DateTime.Now,
                SoldDate = DateTime.Now,
                Color = "Brown",
                Price = 299.99
            }; allPets.Add(pet1);


            Pet pet2 = new Pet
            {
                ID = 2,
                Name = "Arnold",
                Type = type2,
                Birthday = DateTime.Now,
                SoldDate = DateTime.Now,
                Color = "Purple",
                Price = 9999.99
            }; allPets.Add(pet2);
            
            
            Pet pet3 = new Pet
            {
                ID = 3,
                Name = "harry",
                Type = type2,
                Birthday = DateTime.Now,
                SoldDate = DateTime.Now,
                Color = "Purple",
                Price = 9999.99
            }; allPets.Add(pet3);
            
            Pet pet4 = new Pet
            {
                ID = 4,
                Name = "Andreas",
                Type = type3,
                Birthday = DateTime.Now,
                SoldDate = DateTime.Now,
                Color = "Green",
                Price = 1200.98
            }; allPets.Add(pet4);
            Pet pet5 = new Pet
            {
                ID = 5,
                Name = "Manfred",
                Type = type1,
                Birthday = DateTime.Now,
                SoldDate = DateTime.Now,
                Color = "Orange",
                Price = 10.45,
            }; allPets.Add(pet5);
            Pet pet6 = new Pet
            {
                ID = 6,
                Name = "Janina",
                Type = type3,
                Birthday = DateTime.Now,
                SoldDate = DateTime.Now,
                Color = "Black",
                Price = 4666.99,
            }; allPets.Add(pet6);
            Pet pet7 = new Pet
            {
                ID = 7,
                Name = "Bernd",
                Type = type1,
                Birthday = DateTime.Now,
                SoldDate = DateTime.Now,
                Color = "Yellow",
                Price = 99659.99
            }; allPets.Add(pet7);
            return allPets;
        }

        public List<Pet> ReadPets()
        {
            return allPets;
        }
        public void DeletePet(int id)
        {
            List<Pet> pets = allPets;
            foreach (Pet pet in pets.ToList())
            {
                if (pet.ID.Equals(id))
                {
                    pets.Remove(pet);
                }
            }
        }
        public void createPet(Pet pet)
        {
            Pet newPet = new Pet();
            newPet.ID = pet.ID;
            newPet.Name = pet.Name;
            newPet.Type = pet.Type;
            newPet.Birthday = pet.Birthday;
            newPet.SoldDate = pet.SoldDate;
            newPet.Color = pet.Color;
            newPet.Price = pet.Price;
            allPets.Add(newPet);
        }

        public void UpdateName(int id, string name)
        {
            List<Pet> Pets = allPets;
            Pets.First(pet => pet.ID == id).Name = name;
            Console.WriteLine($"The name has been updated to: {name}.\n");
        }

        public void UpdateColor(int id, string color)
        {
            List<Pet> Pets = allPets;
            Pets.First(pet => pet.ID == id).Color = color;
            Console.WriteLine($"The Color has been updated to: {color}.\n");
            
        }

        public void UpdatePrice(int id, double price)
        {
            List<Pet> Pets = allPets;
            Pets.First(pet => pet.ID == id).Price = price;
            Console.WriteLine($"The Color has been updated to: {price}.\n");
            
        }

        public void UpdateType(int id, PetType type)
        {
            List<Pet> Pets = allPets;
            Pets.First(pet => pet.ID == id).Type = type;
            Console.WriteLine(type.Name);
        }

        public void UpdateBirthday(int id, DateTime birthday)
        {
            List<Pet> Pets = allPets;
            Pets.First(pet => pet.ID == id).Birthday = birthday;
            Console.WriteLine(birthday);
        }

        public void UpdateSoldDate(int id, DateTime SoldDate)
        {
            List<Pet> Pets = allPets;
            Pets.First(pet => pet.ID == id).SoldDate = SoldDate;
            Console.WriteLine(SoldDate);
        }
        
        public DateTime DateTimeSetter(int year, int month, int day, int hour, int minute, int second)
        {
            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);
            return dateTime;
        }
        public DateTime SoldSetter(int year, int month, int day, int hour, int minute, int second)
        {
            DateTime soldTime = new DateTime(year, month, day, hour, minute, second);
            return soldTime;
        }
    }
}