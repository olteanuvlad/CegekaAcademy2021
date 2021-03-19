namespace GenericsExercise.Console
{
    public class University : IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public University()
        {
            Id = null;
            Name = null;
            Address = null;
        }

        public University(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"[{Id}]: {Name}, {Address}";
        }
    }
}