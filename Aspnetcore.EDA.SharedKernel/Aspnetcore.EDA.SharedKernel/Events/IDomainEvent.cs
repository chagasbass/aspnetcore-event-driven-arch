namespace Aspnetcore.EDA.SharedContext.Base.Events
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTime OccuredAt { get; }
    }
}
