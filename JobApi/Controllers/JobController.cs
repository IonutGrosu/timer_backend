using JobApi.Models;
using JobApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobApi.Controllers;

[ApiController]
[Route("job")]
public class JobController : ControllerBase
{
    private IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPut]
    [Route("{id}/duedate")]
    public async Task<ActionResult> UpdateDueDate([FromRoute] string id,
        [FromBody] DueDate newDueDate)
    {
        try
        {
            await _jobService.UpdateDueDate(id, newDueDate);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}