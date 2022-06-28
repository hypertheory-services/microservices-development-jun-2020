using CoursesApi.Domain;

using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers;

public class CoursesController : ControllerBase
{
    private readonly CoursesData _data;

    public CoursesController(CoursesData data)
    {
        _data = data;
    }

    [HttpGet("courses")]
    public async Task<ActionResult> GetAllCourses()
    {
        var response = await _data.GetAllCoursesAsync();
        return Ok(response);
    }
}
