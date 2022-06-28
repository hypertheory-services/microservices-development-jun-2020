using CoursesApi.Domain;
using CoursesApi.Models;

using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers;

[ApiController]
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

    [HttpPost("courses/services")]
    public async Task<ActionResult> AddCourseToServicesCategory([FromBody] CourseCreateModel request) {

        GetCoursesItemModel response = await _data.AddCourseToServicesAsync(request);
        return StatusCode(201, response);
    }

     [HttpPost("courses/angular")]
    public async Task<ActionResult> AddCourseToAngularCategory([FromBody] CourseCreateModel request) {
         GetCoursesItemModel response = await _data.AddCourseToAngularAsync(request);
        return StatusCode(201, response);
    }
}
