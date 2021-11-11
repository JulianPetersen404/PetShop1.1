using System;
using System.Threading;
using PetShop1._1.Core.Models;

namespace PetShop1._1.UI
{
    public class StringConstants
    {
        public const string WelcomeMessage = "     Welcome to \n__-Julians PetShop-__\n\n\n";
        public const string Menu = "What do You want to do?\n(Select a Number)*\n\n" +
                                              "1. List all the pets\n" +
                                              "2. Add a new pet to the Store\n" +
                                              "3. Change pet informations\n" +
                                              "4. Delete pet\n";

        
        public const string WhichPetDelete = "Which pet do you want to delete (pet id)";
        public const string deleted = "has been deleted.";
        public const string WhichPetUpdate ="Which pet do you want to update (pet id)?";
        public const string WhatToUpdate = "What do you want to update?\n" +
                                           "1: Name\n2: Color\n3: Price\n4: Type\n5: Birthday\n6: Last Time Sold\n7:Leave";
        public const string MainWindow = "To go back to the main window press 0";
        public const string Name ="What is the pets name?";
        public const string Type = "What is the pet`s species?";
        public const string Birthday = "When was the pet born?(Day/Month/Year)";
        public const string SoldDate = "when was the last time it was sold(Day/Month/Year)?";
        public const string Color = "which color does the pet have?";
        public const string Price = "what should the pet cost?(2 decimal(0000,00))";
        


    }
}