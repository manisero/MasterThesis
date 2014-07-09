namespace Schema.Model
{
    public class KeySpace : INamed
    {
        public string Name { get; set; }

        public string ReplicationClass { get; set; }

        public int ReplicationFactor { get; set; }
    }
}
