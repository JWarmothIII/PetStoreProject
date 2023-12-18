namespace PetStore.Shared.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public required string? Type { get; set; }
        public required string? Breed { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? DateAvailable { get; set; }
        public int Price { get; set; }
        public string? ImgURL { get; set; }

    }
}
