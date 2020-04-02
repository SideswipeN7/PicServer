namespace Pic.Shared.Abstraction
{
    public abstract class DbEntity
    {
        public abstract string? GetKey { get; }
    }
}