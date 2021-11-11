using System;
using System.Security.Authentication.ExtendedProtection;
using Data;
using PetShop1._1.Core.IServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PetShop1._1.Domain.IRepositories;
using PetShop1._1.Domain.Services;

namespace PetShop1._1.UI
{
    class Program
    {

        
        
        
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();

            IPetRepository _repository = new PetRepository();
            IPetTypeRepository _petTypeRepository = new PetTypeRepository();
            IPetService _petService = new PetService(_repository);
            IPetTypeService _petTypeService = new PetTypeService(_petTypeRepository);

            Menu menu = new Menu(_petService, _petTypeService);
            menu.Start();


        }

        
    }
}