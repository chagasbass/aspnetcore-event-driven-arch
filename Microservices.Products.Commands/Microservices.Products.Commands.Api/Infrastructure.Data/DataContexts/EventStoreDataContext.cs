namespace Microservices.Products.Commands.Api.Infrastructure.Data.DataContexts;

public class EventStoreDataContext
{
    private readonly BaseConfigurationOptions _options;
    public IMongoDatabase ConexaoMongo { get; private set; }

    public EventStoreDataContext(IOptions<BaseConfigurationOptions> options)
    {
        _options = options.Value;
        Conectar();
    }

    private void ConfigurarConexoes()
    {
        var configuracoes = MongoClientSettings.FromConnectionString("");
        configuracoes.MaxConnectionIdleTime = TimeSpan.FromSeconds(30);
        configuracoes.UseTls = false;
        configuracoes.RetryWrites = true;
        configuracoes.ServerApi = new ServerApi(ServerApiVersion.V1);

        var cliente = new MongoClient(configuracoes);

        ConexaoMongo = cliente.GetDatabase("");
    }

    public void Conectar() => ConfigurarConexoes();

    #region Coleções
    public IMongoCollection<EventModel> Events => ConexaoMongo.GetCollection<EventModel>("Events");

    #endregion
}
