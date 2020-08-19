namespace SerializingObjects
{
    public class NameValidationAtribute : System.Attribute
    {
        public string Name { get; set; }
        public NameValidationAtribute() {}
        public NameValidationAtribute(string name)
        {
            Name = name;
        }
    }
}