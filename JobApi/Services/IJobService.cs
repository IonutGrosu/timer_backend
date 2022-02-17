using JobApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobApi.Services;

public interface IJobService
{
    public Task UpdateDueDate(String id, DueDate newDueDate);
}