namespace BirthdayCelebrations
{
    public class Pet : IBirthdable
    {
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}