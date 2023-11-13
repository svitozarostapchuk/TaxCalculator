namespace Data.Entities.Interfaces
{
    public interface IHasId<TKey>
    {
        TKey Id { get; set; }
    }
}
