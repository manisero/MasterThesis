namespace Schema.Model
{
    public class ViewField : INamed
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsKey { get; set; }

        public int? OnKeyPostion { get; set; }

        public bool IsSearchable { get; set; }
    }
}
