using JobApi.Models;
using RestEase;

namespace JobApi.Api;

public interface IJobApi
{
    [Put("job/{id}/duedate")]
    Task UpdateDueDateAsync([Path]string id, [Body]DueDate newDueDate);
}