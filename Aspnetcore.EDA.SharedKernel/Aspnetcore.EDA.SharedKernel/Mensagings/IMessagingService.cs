using Aspnetcore.EDA.SharedContext.Base.Events;

namespace Aspnetcore.EDA.SharedContext.Base.Mensagings
{
    public interface IMessagingService
    {
        public Task QueueAsync(IDomainEvent domainEvent);
    }
}
