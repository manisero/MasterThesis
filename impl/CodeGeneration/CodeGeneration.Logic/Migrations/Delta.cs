using System.Collections.Generic;

namespace CodeGeneration.Logic.Migrations
{
    public class Delta
    {
        public Delta()
        {
            SimplePropertyDeltas = new Dictionary<string, SimplePropertyDelta>();
            ComplexPropertyDeltas = new Dictionary<string, Delta>();
            SimpleCollectionDeltas = new Dictionary<string, SimpleCollectionDelta>();
            ComplexCollectionDeltas = new Dictionary<string, ComplexCollectionDelta>();
        }

        public IDictionary<string, SimplePropertyDelta> SimplePropertyDeltas { get; set; }

        public IDictionary<string, Delta> ComplexPropertyDeltas { get; set; }

        public IDictionary<string, SimpleCollectionDelta> SimpleCollectionDeltas { get; set; }

        public IDictionary<string, ComplexCollectionDelta> ComplexCollectionDeltas { get; set; }

        public bool IsEmpty()
        {
            return SimplePropertyDeltas.Count == 0 &&
                   ComplexPropertyDeltas.Count == 0 &&
                   SimpleCollectionDeltas.Count == 0 &&
                   ComplexCollectionDeltas.Count == 0;
        }
    }

    public class SimplePropertyDelta
    {
        public dynamic OldValue { get; set; }

        public dynamic NewValue { get; set; }
    }

    public class SimpleCollectionDelta
    {
        public SimpleCollectionDelta()
        {
            RemovedItems = new List<dynamic>();
            AddedItems = new List<dynamic>();
        }

        public ICollection<dynamic> RemovedItems { get; set; }

        public ICollection<dynamic> AddedItems { get; set; }

        public bool IsEmpty()
        {
            return RemovedItems.Count == 0 &&
                   AddedItems.Count == 0;
        }
    }

    public class ComplexCollectionDelta
    {
        public ComplexCollectionDelta()
        {
            RemovedItems = new List<dynamic>();
            AddedItems = new List<dynamic>();
            ModifiedItems = new Dictionary<string, Delta>();
        }

        public ICollection<dynamic> RemovedItems { get; set; }

        public ICollection<dynamic> AddedItems { get; set; }

        public IDictionary<string, Delta> ModifiedItems { get; set; }

        public bool IsEmpty()
        {
            return RemovedItems.Count == 0 &&
                   AddedItems.Count == 0 &&
                   ModifiedItems.Count == 0;
        }
    }
}
