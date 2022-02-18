using JobApi.Api;
using JobApi.Models;
using Newtonsoft.Json;
using RestEase;

namespace JobApi.Services.Implementation;

public class JobService : IJobService
{
    private IJobApi api;

    public JobService()
    {
        var settings = new JsonSerializerSettings()
        {
            DateFormatString = "yyyy-MM-dd'T'HH:mm:ss.SSSZ"
        };
        api = new RestClient("http://localhost:8080/engine-rest")
        {
            JsonSerializerSettings = settings
        }.For<IJobApi>();
    }

    public async Task UpdateDueDate(string id, DueDate newDueDate)
    {
        try
        {
            await api.UpdateDueDateAsync(id, newDueDate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}