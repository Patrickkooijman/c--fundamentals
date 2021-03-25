namespace GradeBook
{
    public class NamedObject: object
    {
        protected NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set;  }
    }
}