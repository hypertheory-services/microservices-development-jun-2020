using CoursesApi.Adapters;
using CoursesApi.Models;

using Google.Protobuf.WellKnownTypes;

using messages = Courses.Messages;
namespace CoursesApi.Domain;

public class CoursesPublish
{
    private readonly CoursesPubSubAdapter _adapter;
    private readonly ILogger<CoursesPublish> _logger;
    public CoursesPublish(CoursesPubSubAdapter adapter, ILogger<CoursesPublish> logger)
    {
        _adapter = adapter;
        _logger = logger;
    }

    public async Task PublishCourseAsync(Course course)
    {
        // map that sucker to a message type
        var msg = new messages.Course()
        {
            Id = course.Id.ToString(),
            Created = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime()),
            Body = new messages.Course.Types.CourseInformation
            {
                Id = course.Id.ToString(),
                Title = course.Title,
                Category = course.Category,
                Description = course.Description,
                NumberOfDays = course.NumberOfDays
            }
        };
        await _adapter.PublishCourseAsync(msg);
    }
}
