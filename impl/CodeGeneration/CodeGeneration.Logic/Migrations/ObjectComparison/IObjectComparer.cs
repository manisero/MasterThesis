namespace CodeGeneration.Logic.Migrations.ObjectComparison
{
    public interface IObjectComparer
    {
        Delta Compare<T>(T old, T @new);
    }
}
