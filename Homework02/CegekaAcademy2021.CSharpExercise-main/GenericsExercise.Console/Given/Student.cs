namespace GenericsExercise.Console
{
    public class Student : IEntity
    {
        public string Id { get; set; }

        public string FisrtName { get; set; }
        public string LastName { get; set; }

        public Student()
        {
            Id = null;
            FisrtName = null;
            LastName = null;
        }

        public Student(string id, string firstName, string lastName)
        {
            Id = id;
            FisrtName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"[{Id}]: {LastName} {FisrtName}";
        }
    }
}