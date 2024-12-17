namespace Function;

using BadLibrary;
using GoodLibrary;
using Microsoft.Extensions.DependencyInjection;
using SDK;

public class Function : IHostedApp
{
    void IHostedApp.ConfigureServices(IServiceCollection collection)
    {
        collection.AddSingleton<ISettingsProvider, BadClass>();
    }

    async Task IHostedApp.Run()
    {
        await TodoWrapper.CallGetTodos();
    }
}
