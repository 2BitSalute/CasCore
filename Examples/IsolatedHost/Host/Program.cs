using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using DouglasDwyer.CasCore;

var goodLibraryFullPath = Path.GetFullPath(@"..\GoodLibrary\bin\Debug\net9.0\GoodLibrary.dll");

var tryLoad = Assembly.LoadFrom(goodLibraryFullPath);

var policy = new CasPolicyBuilder()   // Create a new, empty whitelist.
    .WithDefaultSandbox()   // Add all system types that are on the default whitelist
    .Allow(new AssemblyBinding(tryLoad, Accessibility.Protected))
    .Build();  // Generate the final policy

var loadContext = new CasAssemblyLoader(policy);

var functionFullPath = Path.GetFullPath(@"..\Function\bin\Debug\net9.0\Function.dll");
var assembly = loadContext.LoadFromAssemblyPath(functionFullPath);

var types = assembly.GetTypes().Where(type => typeof(SDK.IHostedApp).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);

foreach (var type in types)
{
    var potentialImplementation = Activator.CreateInstance(type);
    if (potentialImplementation is SDK.IHostedApp implementation)
    {
        await implementation.Run();
    }
}