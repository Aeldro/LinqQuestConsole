namespace LinqQuest.Models
{
    public class Animal
    {
        public Guid Id { get; set; }
        public String Name { get; set; } = string.Empty;
        public int SpecieId { get; set; }
        public Specie Specie { get; set; }
    }
}
