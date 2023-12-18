using PetStore.Shared.Entities;

namespace PetStore.Shared.Services
{
    public interface IPetService
    {
        Task<List<Pet>> GetAllPets();
        Task<List<Pet>> GetAllDogs();
        Task<List<Pet>> GetAllCats();
        Task<Pet> GetPetById(int id);
        Task<Pet> AddPet(Pet pet);
        Task<Pet> EditPet(int id, Pet pet);
        Task<bool> DeletePet(int id);
        
    }
}
