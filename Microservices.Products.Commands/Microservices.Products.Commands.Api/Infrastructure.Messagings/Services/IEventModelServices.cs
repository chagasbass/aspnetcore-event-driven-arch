using Confluent.Kafka;
using Microservices.Products.Commands.Api.Shared.Configurations;
using System.Text.Json;

namespace Microservices.Products.Commands.Api.Infrastructure.Messagings.Services;

public interface IEventModelServices
{
    Task RaiseEventAsync(BaseEvent baseEvent);
}

public class EventModelServices : IEventModelServices
{
    private readonly ApiConfigurationOptions _options;
    private readonly ProducerConfig _producerConfig;

    public EventModelServices(IOptions<ApiConfigurationOptions> options)
    {
        _options = options.Value;

        _producerConfig = new ProducerConfig
        {
            BootstrapServers = _options.BootstrapServer
        };

    }

    public async Task RaiseEventAsync(BaseEvent baseEvent)
    {
        using var producer = new ProducerBuilder<string, string>(_producerConfig)
                               .SetKeySerializer(Serializers.Utf8)
                               .SetValueSerializer(Serializers.Utf8)
                               .Build();

        var dataJson = JsonSerializer.Serialize(baseEvent);

        var message = new Message<string, string>
        {
            Key = Guid.NewGuid().ToString(),
            Value = dataJson
        };

        var deliveryResult = await producer.ProduceAsync(_options.Topic, message);

        if (deliveryResult.Status == PersistenceStatus.NotPersisted)
        {
            //todo Gerar erro
        }
    }
}
