﻿namespace Schema.Model
{
    public class FieldPresence
    {
        public string View { get; set; }

        public string As { get; set; }

        public bool IsKey { get; set; }

        public int? OnKeyPosition { get; set; }

        public bool IsSearchable { get; set; }
    }
}
