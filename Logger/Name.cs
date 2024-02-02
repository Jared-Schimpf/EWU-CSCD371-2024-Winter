namespace Logger
{
    public class Name(string firstName, string lastName)
    {
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}