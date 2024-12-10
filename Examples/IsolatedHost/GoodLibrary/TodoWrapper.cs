namespace GoodLibrary;

public class TodoWrapper
{
    public static async Task<string> CallGetTodos()
    {
        using var httpClient = new HttpClient();
        var webRequest = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7146/todoitems");

        var response = await httpClient.SendAsync(webRequest);
        string content = await response.Content.ReadAsStringAsync();

        return content;
    }
}
