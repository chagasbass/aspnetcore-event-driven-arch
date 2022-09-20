namespace Microservices.Products.Commands.Api.Shared.Configurations;

public class ApiConfigurationOptions
{
    public const string BaseConfig = "ApiConfigurations";
    public string? StringConexaoBanco { get; set; }
    public string? BootstrapServer { get; set; }
    public int SessionTimeoutMs { get; set; }
    public int ConsumeTimeout { get; set; }
    public string? GroupId { get; set; }
    public string? Topic { get; set; }

    public ApiConfigurationOptions() { }

}