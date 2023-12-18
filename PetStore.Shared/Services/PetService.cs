using Microsoft.EntityFrameworkCore;
using PetStore.Shared.Data;
using PetStore.Shared.Entities;

namespace PetStore.Shared.Services
{
    public class PetService : IPetService
    {
        private readonly DataContext _context;

        public PetService(DataContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task<bool> DeletePet(int id)
        {
           var dbPet = await _context.Pets.FindAsync(id);
            if (dbPet != null)
            {
                _context.Pets.Remove(dbPet);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Pet> EditPet(int id, Pet pet)
        {
            var dbPet = _context.Pets.Find(id);
            if (dbPet != null)
            {
                dbPet.Type = pet.Type;
                dbPet.Breed = pet.Breed;
                dbPet.Name = pet.Name;
                dbPet.Age = pet.Age;
                dbPet.DateAvailable = pet.DateAvailable;
                dbPet.Price = pet.Price;
                dbPet.ImgURL = pet.ImgURL;

                await _context.SaveChangesAsync();
                return dbPet;
            }
            throw new Exception("Pet not found");
        }

        public async Task<List<Pet>> GetAllPets()
        {
           var pets = await _context.Pets.ToListAsync();
            return pets;
        }

        public async Task<List<Pet>> GetAllDogs()
        {
            var dogs = await _context.Pets.Where(p => p.Type == "Dog").ToListAsync();
            return dogs;
        }

        public async Task<List<Pet>> GetAllCats()
        {
            var cats = await _context.Pets.Where(p => p.Type == "Cat").ToListAsync();
            return cats;
        }


        public async Task<Pet> GetPetById(int id)
        {
            return await _context.Pets.FindAsync(id);
        }
    }
}
