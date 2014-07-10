namespace Schema.Model
{
    public class EventField : INamed
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsNullable { get; set; }
    }
}
