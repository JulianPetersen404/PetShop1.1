﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using Data;
using Microsoft.VisualBasic;
using PetShop1._1.Core.IServices;
using PetShop1._1.Core.Models;

namespace PetShop1._1.UI
{
    internal class Menu
    {
        private IPetService _petService;
        private IPetTypeService _petTypeService;

        public Menu(IPetService petService, IPetTypeService petTypeService)
        {
            _petService = petService;
            _petTypeService = petTypeService;
        }
        public void Start()
        {
            _petService.GetPets();
            foreach (var c in StringConstants.WelcomeMessage)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }
            Thread.Sleep(2000);
            Console.WriteLine(StringConstants.Menu);
            DefaultLoop();
        }
        private void DefaultLoop()
        {
            int input;
            while ((input = DefaultLoopSelection()) != -1)
            {
                if (input == 1)
                {
                    ShowAllPets();
                    ShowMainMenu();
                }
                if (input == 2)
                {
                    AddPet();
                }
                if (input == 3)
                {
                    UpdatePet();
                }
                if (input == 4)
                {
                    DeletePet();
                }

                if (input == 5)
                {
                    ShowPetsByType();
                }

                if (input == 6)
                {
                    PetsSortedByPrice();
                }
                if (input == 7)
                {
                    TopFiveCheapestPets();
                }
            }
        }
        public void TopFiveCheapestPets()
        {
            List<Pet> pets = _petService.ReadPets().OrderBy(p=> p.Price).ToList();
            
            foreach (var p in pets.GetRange(0,5))
            { 
                printPetInformations(p);
            }
            ShowMainMenu();
        }
        public void PetsSortedByPrice()
        {
            List<Pet> pets = _petService.ReadPets().OrderByDescending(p => p.Price).ThenBy(p => p.Name).ToList();
            foreach (var p in pets)
            {
                printPetInformations(p);
            }
            ShowMainMenu();
        }
        public void ShowPetsByType()
        {
            List<Pet> pets = _petService.ReadPets();
            Console.WriteLine(StringConstants.ShowPetsByType);
            printAllTypes();
            int id = StringToInt(Console.ReadLine());
            
            foreach (var pet in pets.Where(p => p.Type.ID == id))
            {
                printPetInformations(pet);
            }
            ShowMainMenu();
        }
        private void ShowAllPets()
        {
            List<Pet> pets = _petService.ReadPets();
            foreach (Pet pet in pets)
            {
                printPetInformations(pet);
            }
            Console.WriteLine("\n");
        }
        private void AddPet()
        {
            List<Pet> pets = _petService.ReadPets();
            Pet pet = new Pet();
            
            //ID autogenerated.
            pet.ID = _petService.ReadPets().Max(pet => pet.ID)+1;
            //Name
            Console.WriteLine(StringConstants.Name);
            pet.Name = Console.ReadLine();
            //Color
            Console.WriteLine(StringConstants.Color);
            pet.Color = Console.ReadLine();
            //price
            Console.WriteLine(StringConstants.Price);
            pet.Price = StringToDouble();
            //Type
            Console.WriteLine(StringConstants.Type);
            printAllTypes();
            pet.Type = _petTypeService.GetPetTypes()[StringToInt(Console.ReadLine())];
            //Birthday
            Console.WriteLine(StringConstants.Birthday);
            string birthDay = Console.ReadLine();
            var parsedBD = DateTime.Parse(birthDay);
            pet.Birthday = parsedBD;
            //Sold
            Console.WriteLine(StringConstants.SoldDate);
            string soldDate = Console.ReadLine();
            var parsedSoldD = DateTime.Parse(soldDate);
            pet.SoldDate = parsedSoldD;
            pets.Add(pet);
            printPetInformations(pet);
            ShowMainMenu();
        }

        private void UpdatePet()
        {
            ShowAllPets();
            Console.WriteLine(StringConstants.WhichPetUpdate);
            int pet = StringToInt(Console.ReadLine());
            Console.WriteLine(StringConstants.WhatToUpdate);
            int choice = StringToInt(Console.ReadLine());
            UpdateLoop(pet,choice);
        }
        private void DeletePet()
        {
            ShowAllPets();
            Console.WriteLine(StringConstants.WhichPetDelete);
            int choice = StringToInt(Console.ReadLine());
            if (choice > 0)
            {
                _petService.DeletePet(choice);
                Console.WriteLine($"{choice} {StringConstants.deleted}");
            }
            ShowMainMenu();
        }
        private void UpdateLoop(int id,int input)
        {
            switch (input)
            {
               case 1:
                  Console.WriteLine(StringConstants.Name);
                  string realName = Console.ReadLine();
                  _petService.UpdateName(id, realName);
                  break;
               case 2:
                   Console.WriteLine(StringConstants.Color);
                   string realColor = Console.ReadLine();
                   _petService.UpdateColor(id, realColor);
                   break;
               case 3:
                   Console.WriteLine(StringConstants.Price);
                   double price = StringToDouble();
                   _petService.UpdatePrice(id, price);
                   break;
               case 4:
                   printAllTypes();
                   List<PetType> petTypes = _petTypeService.GetPetTypes();
                   Console.WriteLine(StringConstants.Type);
                   PetType type = petTypes[StringToInt(Console.ReadLine())-1];
                   _petService.UpdateType(id, type);
                   break;
               case 5:
                   Console.WriteLine(StringConstants.Birthday);
                   _petService.UpdateBirthday(id, DateTime.Parse(Console.ReadLine()));
                   break;
               case 6:
                   Console.WriteLine(StringConstants.SoldDate);
                   _petService.UpdateSoldDate(id, DateTime.Parse(Console.ReadLine()));
                   break;
               case 7:
                   MainMenu();
                   break;
            }
            ShowMainMenu();
        }
        private void printPetInformations(Pet pet)
        {
            Console.WriteLine($"ID: {pet.ID}. | Name: {pet.Name}. | Birthday: {pet.Birthday}. | Type: {pet.Type.Name}. | Color: {pet.Color}. |" +
                              $" Price: {pet.Price}. | Last time sold: {pet.SoldDate}");
        }
        private void printAllTypes()
        {
            List<PetType> petTypes = _petTypeService.GetPetTypes();
            foreach (var petType in petTypes)
            {
                Console.WriteLine($"ID:  {petType.ID}. | Name: {petType.Name}.\n");
            }
        }
        private double StringToDouble()
        {
            var stringInput = Console.ReadLine();
            double price;
            if (double.TryParse(stringInput, out price))
            {
                return price;
            }
            return 00.00;
        }
        private int StringToInt(string input)
        {
            int output;
            while (int.TryParse(input, out output))
            {
                return output;
            }
            return 0;
        }
        private int DefaultLoopSelection()
        {
            string input = Console.ReadLine();
            int number;
            if (int.TryParse(input, out number))
            {
                return number;
            }
            return -1;
        }
        private void ShowMainMenu()
        {
            int choice = 1;
            while (choice != 0)
            {
                Console.WriteLine(StringConstants.MainWindow);
                choice = StringToInt(Console.ReadLine());
            }
            MainMenu();
        }
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(StringConstants.Menu);
            DefaultLoop();
        }
    }
}