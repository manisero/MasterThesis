namespace CodeGeneration.Logic.Migrations.ObjectComparison
{
    public interface IKeyChangeDetector
    {
        bool IsTheSameItem(object oldItem, string oldKey, object newItem, string newKey);
    }
}
