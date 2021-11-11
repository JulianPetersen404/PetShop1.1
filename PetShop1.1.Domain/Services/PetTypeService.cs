using System.Collections.Generic;
using PetShop1._1.Core.IServices;
using PetShop1._1.Core.Models;
using PetShop1._1.Domain.IRepositories;

namespace PetShop1._1.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {

        
        private IPetTypeRepository _petTypeRepository;
        public PetTypeService(IPetTypeRepository _repository)
        {
            _petTypeRepository = _repository;
        }
        public List<PetType> GetPetTypes()
        {
            return _petTypeRepository.getPetTypes();
        }

        public PetType GetPetType(int id)
        {
            return _petTypeRepository.getPetType(id);
        }
    }
}