using System;

namespace CodeGeneration.Logic.Migrations.ObjectComparison.KeyChangeDetectors
{
    public class InteractiveKeyChangeDetector : IKeyChangeDetector
    {
        public bool IsTheSameItem(object oldItem, string oldKey, object newItem, string newKey)
        {
            Console.WriteLine("{0}, {1}", oldKey, newKey);
            Console.WriteLine("Do these keys of type '{0}' match? (y / n)", oldItem.GetType().Name);

            var answer = Console.ReadLine();
            Console.WriteLine();

            return answer == "y";
        }
    }
}
