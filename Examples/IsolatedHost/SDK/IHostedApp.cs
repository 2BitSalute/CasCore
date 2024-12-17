namespace SDK;

using Microsoft.Extensions.DependencyInjection;

public interface IHostedApp
{
    Task Run();

    void ConfigureServices(IServiceCollection collection);
}