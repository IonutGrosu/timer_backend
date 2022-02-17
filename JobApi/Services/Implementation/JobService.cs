using System.Text;
using JobApi.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JobApi.Services.Implementation;

public class JobService : IJobService
{
    public async Task UpdateDueDate(string id, DueDate newDueDate)
    {
        Console.WriteLine(newDueDate.duedate);

        HttpClient client = new HttpClient();
        string json = JsonSerializer.Serialize(newDueDate);

        StringContent content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        HttpResponseMessage responseMessage =
            await client.PutAsync($"http://localhost:8080/engine-rest/job/{id}/duedate", content);
        if (!responseMessage.IsSuccessStatusCode)
            throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
    }
}