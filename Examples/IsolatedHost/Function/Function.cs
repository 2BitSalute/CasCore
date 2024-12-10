namespace Function;

using GoodLibrary;
using SDK;

public class Function : IHostedApp
{
    public async Task Run()
    {
        await TodoWrapper.CallGetTodos();
    }
}
